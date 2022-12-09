import React, { Component } from "react";
import {
  AppWrapper,
  AppHeader,
  ContentWrapper,
  RadiusSelect,
  FindStationNearMeButton,
  SiteSearchBar,
  HeaderTitle,
  NoResults,
  ErrorRetrievingStations,
  Loading,
} from "./styles";
import SiteList from "./components/SiteList/SiteList";
import MySiteFeedAPI from "./services/MySiteFeedAPI";
import LocationIQAPI from "./services/LocationIQAPI";
import { ReactSearchAutocomplete } from "react-search-autocomplete";

export const SITE_REQUEST_STATUS = {
  NOT_SENT: "NOT_SENT",
  PENDING: "PENDING",
  SUCCESS: "SUCCESS",
  FAILED: "FAILED",
};
class App extends Component {
  constructor() {
    super();
    this.state = {
      locationInputValue: "",
      searchRadiusOptions: [
        {
          value: 1,
          name: "1 site",
        },
        {
          value: 5,
          name: "5 site",
        },
        {
          value: 20,
          name: "20 site",
        },
        {
          value: 100,
          name: "100 site",
        },
      ],
      searchRadiusInMiles: 1,
      sites: null,
      siteRequestStatus: SITE_REQUEST_STATUS.NOT_SENT,
    };
    this.loadDefaultStations();
    this.findStations = this.findStations.bind(this);
    this.findStationsNearMe = this.findStationsNearMe.bind(this);
  }

  componentDidMount() {
    if (navigator.geolocation) {
      console.log("Geolocation is supported!");
    }
    // CanIUse shows support on all browsers so this condition should not be hit.
    else {
      console.log("Geolocation is not supported for this Browser/OS.");
    }
  }

  findStations() {
    const { locationInputValue, searchRadiusInMiles } = this.state;

    this.setState({
      sites: [],
      siteRequestStatus: SITE_REQUEST_STATUS.PENDING,
    });

    LocationIQAPI.getCoordinates(locationInputValue)
      .then((result) =>
        MySiteFeedAPI.getNearbySites(
          result[0].lat,
          result[0].lon,
          searchRadiusInMiles
        )
      )
      .then((result) =>
        this.setState({
          sites: result.sites,
          siteRequestStatus: SITE_REQUEST_STATUS.SUCCESS,
        })
      )
      .catch(() =>
        this.setState({
          sites: [],
          siteRequestStatus: SITE_REQUEST_STATUS.FAILED,
        })
      );
  }

  findStationsNearMe = () => {
    const { searchRadiusInMiles } = this.state;

    this.setState({
      sites: [],
      siteRequestStatus: SITE_REQUEST_STATUS.PENDING,
    });

    const geoSuccess = (position) => {
      MySiteFeedAPI.getNearbySites(
        position.coords.latitude,
        position.coords.longitude,
        searchRadiusInMiles
      )
        .then((data) =>
          this.setState({
            sites: data.sites,
            siteRequestStatus: SITE_REQUEST_STATUS.SUCCESS,
          })
        )
        .catch(() =>
          this.setState({
            sites: [],
            siteRequestStatus: SITE_REQUEST_STATUS.FAILED,
          })
        );
    };

    const geoError = (error) => {
      console.log(error);
      switch (error.code) {
        case error.PERMISSION_DENIED:
          // geolocation can be denied in a few condition: 1) user denied, 2) denied due to not serving site over https.
          console.log(
            `Denied geolocation for the following reason: ${error.message}`
          );
          break;
        case error.POSITION_UNAVAILABLE:
          console.log("Position Unavailable");
          break;
        case error.TIMEOUT:
          console.log("Geolocation timed out");
          break;
      }
    };
    navigator.geolocation.getCurrentPosition(geoSuccess, geoError);
  };

  loadDefaultStations = () => {
    this.setState({
      sites: [],
      siteRequestStatus: SITE_REQUEST_STATUS.PENDING,
    });

    MySiteFeedAPI.getNearbySites(51.5076537, -0.182948, 100)
      .then((data) =>
        this.setState({
          sites: data.sites,
          siteRequestStatus: SITE_REQUEST_STATUS.SUCCESS,
        })
      )
      .catch(() =>
        this.setState({
          sites: [],
          siteRequestStatus: SITE_REQUEST_STATUS.FAILED,
        })
      );
  };

  handleInputChange = (event) => {
    this.setState({ locationInputValue: event.target.value });
  };

  handleSelectChange = (event) => {
    this.setState({ searchRadiusInMiles: event.target.value });
  };

  renderSites() {
    const { sites, siteRequestStatus } = this.state;

    if (
      sites &&
      sites.length === 0 &&
      siteRequestStatus === SITE_REQUEST_STATUS.SUCCESS
    ) {
      return <NoResults>No Results Found</NoResults>;
    } else if (sites && sites.length) {
      return <SiteList stations={sites} />;
    } else if (
      sites &&
      sites.length === 0 &&
      siteRequestStatus === SITE_REQUEST_STATUS.FAILED
    ) {
      return (
        <ErrorRetrievingStations>
          Error retrieving sites
        </ErrorRetrievingStations>
      );
    }
  }

  renderSearch() {
    const formatResult = (item) => {
      return (
        <>
          <span style={{ display: "block", textAlign: "left" }}>
            {item.siteName}
          </span>
        </>
      );
    };

    const handleOnSelect = (item) => {
      const items = [item];
      this.setState({
        sites: items,
        siteRequestStatus: SITE_REQUEST_STATUS.SUCCESS,
      });
    };

    const { sites } = this.state;
    if (sites && sites.length) {
      return (
        <ReactSearchAutocomplete
          items={sites}
          onSelect={handleOnSelect}
          autoFocus
          formatResult={formatResult}
          fuseOptions={{ keys: ["id", "siteName"] }}
          resultStringKeyName="siteName"
        />
      );
    }
    return null;
  }

  renderLoading() {
    const { siteRequestStatus } = this.state;
    if (siteRequestStatus === SITE_REQUEST_STATUS.PENDING) {
      return <Loading>Loading...</Loading>;
    } else {
      return null;
    }
  }

  render() {
    const { siteRequestStatus, searchRadiusOptions } = this.state;
    const pendingRequest =
      siteRequestStatus === SITE_REQUEST_STATUS.PENDING;

    return (
      <AppWrapper>
        <AppHeader>
          <HeaderTitle>bp Demo App</HeaderTitle>
        </AppHeader>
        <ContentWrapper className="col-xs-12">
          <SiteSearchBar className="col-md-8 offset-md-2">
            <div className="input-group">
              <div className="input-group-append">
                <RadiusSelect
                  className="form-control"
                  disabled={pendingRequest}
                  onChange={this.handleSelectChange}
                >
                  {searchRadiusOptions.map((option, i) => {
                    return (
                      <option key={i} value={option.value}>
                        {option.name}
                      </option>
                    );
                  })}
                </RadiusSelect>
                <FindStationNearMeButton
                  className="btn btn-primary"
                  disabled={pendingRequest}
                  onClick={this.findStationsNearMe}
                >
                  Find the closest sites
                </FindStationNearMeButton>
              </div>
            </div>
            <div className="wrapper">{this.renderSearch()}</div>
          </SiteSearchBar>
          {this.renderLoading()}
          {this.renderSites()}
        </ContentWrapper>
      </AppWrapper>
    );
  }
}

export default App;

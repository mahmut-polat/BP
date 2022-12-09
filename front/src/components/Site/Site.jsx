import React, { Component } from "react";
import locationIcon from "../../assets/images/location-pin.png";
import Popup from "reactjs-popup";
import "reactjs-popup/dist/index.css";
import MySiteFeedAPI from "../../services/MySiteFeedAPI";
import bpLogo from "../../assets/images/bp-helios-card.png";

import {
  Wrapper,
  LogoWrapper,
  Name,
  AddressLine1,
  DistanceToLocation,
  PricesWrapper,
  RegularPrice,
  SiteTypeHeader,
  SiteInfoWrapper,
  SiteInfo,
  SiteTypeWrapper,
  LocationPin,
} from "./styles";
import "../../index.css";

export const FILL_UP_REQUEST_STATUS = {
  NOT_SENT: "NOT_SENT",
  PENDING: "PENDING",
  SUCCESS: "SUCCESS",
  FAILED: "FAILED",
};

class Site extends Component {
  constructor(props) {
    super(props);
    this.state = { value: "" };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  handleSubmit(station, pump) {
    return (event) => {
      event.preventDefault();

      MySiteFeedAPI.fillUp(station.id, pump.pumpCode, this.state.value)
        .then((data) =>
          this.setState({
            fillUpResponse: data,
            fillUpRequestStatus: FILL_UP_REQUEST_STATUS.SUCCESS,
          })
        )
        .catch(() =>
          this.setState({
            fillUpResponse: [],
            fillUpRequestStatus: FILL_UP_REQUEST_STATUS.FAILED,
          })
        );
    };
  }

  render() {
    const { station } = this.props;
    const { fillUpResponse } = this.state;

    const destinationAddress = `${station.siteName} ${station.location}`;
    const mapLink = `https://www.google.com/maps/dir/?api=1&destination=${destinationAddress}`;

    return (
      <Wrapper className="col-10 offset-1">
        <LogoWrapper className="col-4 col-md-2">
          <img className="logo" src={bpLogo}></img>
        </LogoWrapper>
        <SiteInfoWrapper className="col-8 col-md-10">
          <SiteInfo className="row">
            <div className="col-12 col-md-6">
              <Name>
                {station.siteName}
                <LocationPin href={mapLink} target="_blank">
                  <img src={locationIcon}></img>
                </LocationPin>
              </Name>
              <AddressLine1>{station.location}</AddressLine1>
              <DistanceToLocation>
                Estimated {Math.round(station.distance * 100) / 100} miles away
              </DistanceToLocation>
            </div>
            <PricesWrapper key="{station.id}" className="col-12 col-md-6">
              {station.pumps.map((pump, i) => (
                <SiteTypeWrapper className="col-md-3">
                  <SiteTypeHeader>{pump.type}</SiteTypeHeader>
                  <RegularPrice>{pump.price}</RegularPrice>
                  <Popup
                    trigger={
                      <button className="button fillUpButton"> Fill Up </button>
                    }
                    modal
                    nested
                  >
                    {(close) => (
                      <div className="modal">
                        <div className="header"> Fill Up </div>
                        <div className="content">
                          <form onSubmit={this.handleSubmit(station, pump)}>
                            <div>
                              <label>
                                Fuel Amount:
                                <input
                                  type="number"
                                  name="fuelAmount"
                                  className="fuelAmountInput"
                                  value={this.state.value}
                                  onChange={this.handleChange}
                                />
                              </label>
                            </div>
                            <div>
                              <input
                                type="submit"
                                value="Submit"
                                className="fillUpButton submit"
                              />
                            </div>
                          </form>
                          <br />
                          <div>
                            <label>
                              Remained Litres: {fillUpResponse?.remainedLitres}
                            </label>
                          </div>
                          <div>
                            <label>
                              Total Price: {fillUpResponse?.totalPrice}
                            </label>
                          </div>
                        </div>
                      </div>
                    )}
                  </Popup>
                </SiteTypeWrapper>
              ))}
            </PricesWrapper>
          </SiteInfo>
        </SiteInfoWrapper>
      </Wrapper>
    );
  }
}

export default Site;

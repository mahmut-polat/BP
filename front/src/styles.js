import styled from "styled-components";
import bp from "./assets/images/bp.jpg";

export const AppWrapper = styled.div`
  text-align: center;
`;

export const AppHeader = styled.div`
  height: 350px;
  padding: 20px;
  color: white;
  display: flex;
  align-items: center;
  font-size: 25px;

  background: url(${bp}) no-repeat;
  background-size: cover;
  background-position: 50% 30%;
`;

export const HeaderLogo = styled.img`
  width: 80px;
  height: 80px;
`;

export const HeaderTitle = styled.div`
  margin-left: 10px;
`;

export const ContentWrapper = styled.div``;

export const LocationInput = styled.input`
  @media all and (max-width: 736px) {
    font-size: 12px;
  }
`;

export const RadiusSelect = styled.select`
  @media all and (max-width: 736px) {
    font-size: 12px;
  }
`;

export const FindStationButton = styled.button`
  @media all and (max-width: 736px) {
    font-size: 12px;
  }
`;

export const FindStationNearMeButton = styled.button`
  border-left: black 1px solid;
  @media all and (max-width: 736px) {
    font-size: 12px;
  }
`;

export const SiteSearchBar = styled.div`
  padding-top: 10px;
  padding-bottom: 10px;
  padding: 10px;
`;

export const NoResults = styled.div``;

export const ErrorRetrievingStations = styled.div``;

export const Loading = styled.div``;

import axios from "axios";

class MySiteFeedAPI {
  getNearbySites(latitude, longitude, searchRadius) {
    // hard-coding the distance to search to be in a 10 mile radius
    const article = {
      itemCount: Number(searchRadius),
      latitude: latitude,
      longitude: longitude,
    };

    const url = `https://localhost:44300/api/Site/GetSites`;
    return new Promise((resolve, reject) => {
      axios
        .post(url, article)
        .then((response) => resolve(response.data))
        .catch((error) => {
          console.log(error);
          reject(error);
        });
    });
  }

  fillUp(siteCode, pumpCode, fuelAmount) {
    // hard-coding the distance to search to be in a 10 mile radius
    const fillUp = {
      siteCode: siteCode,
      pumpCode: pumpCode,
      fuelAmount: Number(fuelAmount),
    };

    const url = `https://localhost:44300/api/Pump/FillUp`;
    return new Promise((resolve, reject) => {
      axios
        .post(url, fillUp)
        .then((response) => resolve(response.data))
        .catch((error) => {
          console.log(error);
          reject(error);
        });
    });
  }
}

export default new MySiteFeedAPI();

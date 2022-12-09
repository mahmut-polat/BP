import React from "react";
import { mount } from "enzyme";

import Site from "./Site";

let wrapper;

const DUMMY_STATION = {
  station: "Chevron",
  address: "30 5th street",
  city: "San Diego",
  region: "California",
  zip: "92116",
  country: "United States",
  distance: 0.1,
  reg_price: 1.0,
  mid_price: 1.0,
  pre_price: 1.0,
  pumps: [
    {
      test: 1,
    },
  ],
};

const props = {
  station: DUMMY_STATION,
};


describe("Site", () => {
  it("should exist", () => {
    wrapper = mount(<Site {...props} />);
    expect(wrapper).toBeDefined();
  });
});

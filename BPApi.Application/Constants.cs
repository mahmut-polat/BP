using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application
{
    public class Constants
    {
        public static readonly string WARNING_TITLE = "Warning";
        public static readonly string ERROR_TITLE = "Something went wrong.";
        public static readonly string NOT_EMPTY_ITEM_COUNT_ERROR_TEXT = "Item count can not be empty";
        public static readonly string NOT_EMPTY_LATITUDE_ERROR_TEXT = "Latitude can not be empty";
        public static readonly string NOT_EMPTY_LONGITUDE_ERROR_TEXT = "Longitude can not be empty";
        public static readonly string NOT_EMPTY_SITE_CODE_ERROR_TEXT = "Site Code can not be empty";
        public static readonly string NOT_EMPTY_PUMP_CODE_ERROR_TEXT = "Pump Code can not be empty";
        public static readonly string NOT_EMPTY_FUEL_AMOUNT_ERROR_TEXT = "Fuel Amount can not be empty";
        public static readonly string LOCKED_PUMP_WARNING_MESSAGE = "This pump locked. Customer couldn't get any fuel.";
        public static readonly string THIS_PUMP_COULD_NOT_FIND_ON_SITE_ERROR_MESSAGE = "This pump couldn't find on this site.";
        public static readonly string PETROL_PUMP_TYPE = "Petrol";
        public static readonly string DIESEL_PUMP_TYPE = "Diesel";
    }
}

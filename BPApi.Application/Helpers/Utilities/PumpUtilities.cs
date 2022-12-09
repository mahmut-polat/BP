using BPApi.Domain.Enums;
using System.Collections.Generic;

namespace BPApi.Application.Helpers.Utilities
{
    public static class PumpUtilities
    {
        private readonly static IDictionary<PumpType, string> _pumpTyoeMap = new Dictionary<PumpType, string>()
        {
            { PumpType.Petrol, Constants.PETROL_PUMP_TYPE },
            { PumpType.Diesel, Constants.DIESEL_PUMP_TYPE }
        };


        public static string GetPumpType(PumpType type)
        {
            return _pumpTyoeMap[type];
        }
    }
}

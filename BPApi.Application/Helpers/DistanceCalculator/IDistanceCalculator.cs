using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Application.Helpers.DistanceCalculator
{
    public interface IDistanceCalculator
    {
        double CalculateDistance(double userLatitude, double userLongitude, double siteLatitude, double siteLongitude);
    }
}

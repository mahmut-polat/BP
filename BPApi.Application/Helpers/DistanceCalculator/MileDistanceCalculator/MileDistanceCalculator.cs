using System;

namespace BPApi.Application.Helpers.DistanceCalculator.MileDistanceCalculator
{
    public class MileDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(double userLatitude, double userLongitude, double siteLatitude, double siteLongitude)
        {
            Double teta_degeri = userLatitude - siteLatitude;
            Double mil = Math.Sin(deg2rad(userLongitude)) * Math.Sin(deg2rad(siteLongitude)) +
            Math.Cos(deg2rad(userLongitude)) * Math.Cos(deg2rad(siteLongitude)) * Math.Cos(deg2rad(teta_degeri));

            mil = Math.Acos(mil);
            mil = rad2deg(mil);
            mil = mil * 60 * 1.1515;
            return mil;
        }

        private static double rad2deg(Double rad)
        {
            return rad / Math.PI * 180.0;
        }

        private static Double deg2rad(Double deg)
        {
            return deg * Math.PI / 180.0;
        }
    }
}

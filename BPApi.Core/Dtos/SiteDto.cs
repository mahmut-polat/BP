
using System.Collections.Generic;

namespace BPApi.Domain.Dtos
{
    public class SiteDto
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SiteType { get; set; }
        public bool HasMotorWaySite { get; set; }
        public string Location { get; set; }
        public double Distance { get; set; }
        public List<PumpDto> Pumps { get; set; }
    }
}

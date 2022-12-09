using BPApi.Domain.Common;
using System.Collections.Generic;

namespace BPApi.Domain.Entities
{
    public sealed class Site : BaseEntity
    {
        public string SiteName { get; set; }    
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SiteType { get; set; }
        public bool HasMotorWaySite { get; set; }
        public string Location { get; set; }
        public double Distance { get; set; }
    }
}

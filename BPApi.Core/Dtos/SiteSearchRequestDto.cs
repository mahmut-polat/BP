using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Dtos
{
    public class SiteSearchRequestDto
    {
        public int ItemCount { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SiteName { get; set; }
    }
}

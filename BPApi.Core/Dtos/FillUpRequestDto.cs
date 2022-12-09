using System;
using System.Collections.Generic;
using System.Text;

namespace BPApi.Domain.Dtos
{
    public class FillUpRequestDto
    {
        public string SiteCode { get; set; }    
        public string PumpCode { get; set; }    
        public double FuelAmount { get; set; }  
    }
}

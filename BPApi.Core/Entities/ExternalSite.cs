
namespace BPApi.Domain.Entities
{
    public class ExternalSite
    {
        public double Lng { get; set; }
        public long Id { get; set; }
        public double Lat { get; set; }
        public string Key_SiteType { get; set; }
        public bool Flag_MotorwaySite { get; set; } 
        public string Location { get; set; }    
    }
}

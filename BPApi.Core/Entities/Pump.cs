using BPApi.Domain.Common;
using BPApi.Domain.Enums;

namespace BPApi.Domain.Entities
{
    public sealed class Pump : BaseEntity
    {
        public string SiteCode { get; set; }
        public string PumpCode { get; set; }
        public PumpType Type { get; set; }
        public decimal Price { get; set; }
        public double RemainedLitres { get; set; }
        public bool IsLocked { get; set; }
    }
}

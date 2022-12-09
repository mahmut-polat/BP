using BPApi.Domain.Enums;

namespace BPApi.Domain.Dtos
{
    public class PumpDto
    {
        public string PumpCode { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public double RemainedLitres { get; set; }
        public bool IsLocked { get; set; }
    }
}

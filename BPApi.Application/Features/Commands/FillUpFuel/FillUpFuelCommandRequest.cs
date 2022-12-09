using MediatR;

namespace BPApi.Application.Features.Commands.FillUpFuel
{
    public sealed class FillUpFuelCommandRequest : IRequest<FillUpFuelCommandResponse>
    {
        public string SiteCode { get; }
        public string PumpCode { get; }
        public double FuelAmount { get; }

        public FillUpFuelCommandRequest(
            string siteCode,
            string pumpCode,    
            double fuelAmount
        )
        {
            SiteCode = siteCode;
            PumpCode = pumpCode;
            FuelAmount = fuelAmount;
        }
    }
}

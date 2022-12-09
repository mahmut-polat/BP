using AutoMapper;
using BPApi.Application.Interfaces.Features;
using BPApi.Application.Interfaces.Repositories;
using BPApi.Domain.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace BPApi.Application.Features.Commands.FillUpFuel
{
    public class FillUpFuelCommandHandler : BaseHandler<FillUpFuelCommandRequest, FillUpFuelCommandResponse>
    {
        private readonly IPumpRepository _pumpRepository;

        public FillUpFuelCommandHandler(
            IMapper mapper,
            IPumpRepository pumpRepository,
            AbstractValidator<FillUpFuelCommandRequest> requestValidatior
        ) : base(mapper, requestValidator: requestValidatior)
        {
            _pumpRepository = pumpRepository;
        }

        public async override Task<FillUpFuelCommandResponse> HandleAsync(FillUpFuelCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new FillUpFuelCommandResponse();
            var pump = await _pumpRepository.GetPump(request.SiteCode, request.PumpCode);

            if (pump == null)
            {
                BuildFailedResponse(response, Constants.THIS_PUMP_COULD_NOT_FIND_ON_SITE_ERROR_MESSAGE);

                return response;
            }

            if (pump.IsLocked)
            {
                BuildFailedResponse(response, Constants.LOCKED_PUMP_WARNING_MESSAGE);

                return response;
            }

            return BuildResponse(request, response, pump);
        }

        private FillUpFuelCommandResponse BuildResponse(FillUpFuelCommandRequest request, FillUpFuelCommandResponse response, Pump pump)
        {
            response.SiteCode = pump.SiteCode;
            response.PumpCode = pump.PumpCode;
            response.PumpType = pump.Type;
            response.RemainedLitres = pump.RemainedLitres - request.FuelAmount;
            response.FuelAmount = request.FuelAmount;
            response.TotalPrice = ((decimal)request.FuelAmount * pump.Price) / 100;

            return response;
        }
    }
}

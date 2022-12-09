using FluentValidation;

namespace BPApi.Application.Features.Commands.FillUpFuel.Validators
{
    public class FillUpFuelRequestValidator : AbstractValidator<FillUpFuelCommandRequest>
    {
        public FillUpFuelRequestValidator()
        {
            RuleFor(x => x.SiteCode).NotEmpty().WithMessage(Constants.NOT_EMPTY_SITE_CODE_ERROR_TEXT);
            RuleFor(x => x.PumpCode).NotEmpty().WithMessage(Constants.NOT_EMPTY_PUMP_CODE_ERROR_TEXT);
            RuleFor(x => x.FuelAmount).NotEmpty().WithMessage(Constants.NOT_EMPTY_FUEL_AMOUNT_ERROR_TEXT);
        }
    }
}

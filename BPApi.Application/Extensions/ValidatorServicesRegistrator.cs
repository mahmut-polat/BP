using BPApi.Application.Features.Commands.FillUpFuel;
using BPApi.Application.Features.Commands.FillUpFuel.Validators;
using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode.Validators;
using BPApi.Application.Features.Queries.GetSites.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Application.Extensions
{
    public static class ValidatorServicesRegistrator
    {
        public static void AddValidatorServices(this IServiceCollection services)
        {
            services.AddScoped(
                typeof(AbstractValidator<GetPumpsBySiteCodeQueryRequest>),
                typeof(GetPumpsBySiteCodeRequestValidator)
            );

            services.AddScoped(
                typeof(AbstractValidator<FillUpFuelCommandRequest>),
                typeof(FillUpFuelRequestValidator)
            );

            services.AddScoped(
                typeof(AbstractValidator<GetSitesQueryRequest>),
                typeof(GetSitesRequestValidator)
            );
        }
    }
}

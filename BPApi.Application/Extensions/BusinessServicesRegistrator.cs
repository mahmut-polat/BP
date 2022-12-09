using BPApi.Application.Features.Commands.FillUpFuel;
using BPApi.Application.Features.Queries.GetAllPumps;
using BPApi.Application.Features.Queries.GetPumpsBySiteCode;
using BPApi.Application.Features.Queries.GetSites;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Application.Extensions
{
    public static class BusinessServicesRegistrator
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped(
                typeof(IRequestHandler<GetSitesQueryRequest, GetSitesQueryResponse>),
                typeof(GetSitesQueryHandler)
            );

            services.AddScoped(
                typeof(IRequestHandler<GetPumpsBySiteCodeQueryRequest, GetPumpsBySiteCodeQueryResponse>),
                typeof(GetPumpsBySiteCodeQueryHandler)
            );

            services.AddScoped(
                typeof(IRequestHandler<FillUpFuelCommandRequest, FillUpFuelCommandResponse>),
                typeof(FillUpFuelCommandHandler)
            );
        }
    }
}

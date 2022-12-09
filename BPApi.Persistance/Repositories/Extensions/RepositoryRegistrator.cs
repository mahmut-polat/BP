using BPApi.Application.Interfaces.Repositories;
using BPApi.Persistance.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Persistance.Repositories.Extensions
{
    public static class RepositoryRegistrator
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISiteRepository), typeof(SiteRepository));
            services.AddScoped(typeof(IPumpRepository), typeof(PumpRepository));
        }
    }
}

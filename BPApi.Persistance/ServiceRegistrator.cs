using BPApi.Persistance.Repositories.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Persistance
{
    public static class ServiceRegistrator
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddRepositoryServices();
        }
    }
}

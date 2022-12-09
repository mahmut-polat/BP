using BPApi.Domain.Entities;
using BPApi.Infrastructure.DataReader;
using BPApi.Infrastructure.JsonReader;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Infrastructure
{
    public static class ServiceRegistrator
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(
                typeof(IDataReader<ExternalSite>),
                typeof(JsonReader<ExternalSite>)
            );
        }
    }
}

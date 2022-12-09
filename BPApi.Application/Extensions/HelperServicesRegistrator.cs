using BPApi.Application.Helpers.DistanceCalculator;
using BPApi.Application.Helpers.DistanceCalculator.MileDistanceCalculator;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Application.Extensions
{
    public static class HelperServicesRegistrator
    {
        public static void AddHelperServices(this IServiceCollection services)
        {
            services.AddTransient(
                typeof(IDistanceCalculator),
                typeof(MileDistanceCalculator)
            );
        }
    }
}

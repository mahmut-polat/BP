using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BPApi.Extensions
{
    public static class CorsExtensions
    {
        private static readonly string URL = "http://localhost:3000";

        public static void AddSCorsServices(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("localCors", builder =>
            {
                builder.WithOrigins(URL)
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BPApi.Extensions
{
    public static class SwaggerExtensions
    {
        private static readonly string VERSION = "v1";
        private static readonly string API_NAME = "BP Api";
        private static readonly string SWAGGER_ENDPOINT = "/swagger/v1/swagger.json";

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen
            (
                swagger => swagger.SwaggerDoc
                (
                    VERSION,
                    new OpenApiInfo
                    {
                        Title = API_NAME,
                        Version = VERSION
                    }
                )
            );
        }

        public static void AddSwaggerConfigurations(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    options.DocumentTitle = API_NAME;
                    options.SwaggerEndpoint(SWAGGER_ENDPOINT, API_NAME);
                }
            );
        }
    }
}

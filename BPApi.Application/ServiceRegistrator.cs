using AutoMapper;
using BPApi.Application.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BPApi.Application
{
    public static class ServiceRegistrator
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHelperServices();
            services.AddValidatorServices();
            services.AddBusinessServices();
        }
    }
}

using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedExtensions(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}

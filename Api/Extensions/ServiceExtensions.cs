using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);

                config.AssumeDefaultVersionWhenUnspecified = true;

                config.ReportApiVersions = true;
            });

            return services;
        }
    }
}

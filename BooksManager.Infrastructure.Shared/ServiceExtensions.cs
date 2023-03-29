using BooksManager.Core.Application.Interfaces.Service;
using BooksManager.Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BooksManager.Infrastructure.Shared
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            #region Services
            services.AddHttpContextAccessor();
            services.AddTransient<IContextAccessorWrapper, ContextAccessorWrapper>();
            #endregion

            return services;
        }
    }
}

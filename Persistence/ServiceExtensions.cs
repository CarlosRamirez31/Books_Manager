using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(Books_ManagerContext).Assembly.FullName;

            services.AddDbContext<Books_ManagerContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Books"),
                        x => x.MigrationsAssembly(assembly));
            });

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            return services;
        }
    }
}

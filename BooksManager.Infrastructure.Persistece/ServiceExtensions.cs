using Application.Interfaces;
using BooksManager.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;
using WatchDog;
using WatchDog.src.Enums;

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

            services.AddWatchDogServices(options =>
            {
                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            });

            services.AddTransient(typeof(IGeneryRepository<>), typeof(GeneryRepository<>));
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            

            return services;
        }
    }
}

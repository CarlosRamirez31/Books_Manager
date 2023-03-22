using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WatchDog;
using WatchDog.src.Enums;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddWatchDogServices(options =>
            {
                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            });

            return services;
        }
    }
}

using Domain.Microservices.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Student.Microservice.Application.EventHandlers;
using Student.Microservice.Application.Events;
using Student.Microservice.Application.Services;
using System.Reflection;

namespace Student.Microservice.Application
{
    public static class DependencyInjection
    {
        public static void AddStudentApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddServices();
            services.AddCommands();
            services.AddEvents();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IStudentService, StudentService>();
        }

        public static void AddCommands(this IServiceCollection services)
        {

        }
        public static void AddEvents(this IServiceCollection services)
        {
            services.AddTransient<IEventHandler<AccountCreatedEvent>, AccountCreatedEventHandler>();
        }

    }
}

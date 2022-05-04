using Account.Microservice.Application;
using Account.Microservice.Persistence;
using Domain.Microservices.Core.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Broker;
using Student.Microservice.Application;
using Student.Microservice.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Microservices.IoC
{
    public static class DepenencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Application Events, CQRS Features and Services etc.
            services.AddAccountApplication();
            services.AddStudentApplication();

            // Data Access
            services.AddAccountPersistence(configuration);
            services.AddStudentPersistance(configuration);

        }
    }
}

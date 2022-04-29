using Account.Microservice.Application;
using Account.Microservice.Persistence;
using Domain.Microservices.Core.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Broker;
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

            // Application CQRS Features and Services
            services.AddApplication();

            // Data
            services.AddPersistence(configuration);
        }
    }
}

using Account.Microservice.Application;
using Account.Microservice.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Microservice.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddPersistence(configuration);
        }
    }
}

using Container.Microservices.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Microservice.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices(configuration);
        }
    }
}

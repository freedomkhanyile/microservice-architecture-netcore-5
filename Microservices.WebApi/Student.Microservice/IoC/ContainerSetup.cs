using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Microservice.Infrustucture;

namespace Student.Microservice.IoC
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistance(configuration);
        }
    }
}

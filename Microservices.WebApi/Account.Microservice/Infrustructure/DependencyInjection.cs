using Account.Microservice.Core.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Microservice.Infrustructure
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AcountDbContext>(o =>
               o.UseNpgsql(
                           configuration.GetConnectionString("DefaultConnection"),
                                     b => b.MigrationsAssembly(typeof(AcountDbContext).Assembly.FullName)));

            services.AddTransient<IAccountDbContext>(provider => provider.GetRequiredService<AcountDbContext>());
        }
    }
}

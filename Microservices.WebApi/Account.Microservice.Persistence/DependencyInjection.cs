using Account.Microservice.Application;
using Account.Microservice.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Account.Microservice.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountDbContext>(o =>
                o.UseNpgsql(
                            configuration.GetConnectionString("DefaultConnection"),
                                      b => b.MigrationsAssembly(typeof(AccountDbContext).Assembly.FullName)));

            services.AddTransient<IAccountDbContext>(provider => provider.GetRequiredService<AccountDbContext>());
        }
    }
}

using Account.Microservice.Application.Features.Commands;
using Account.Microservice.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Account.Microservice.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddServices();
            services.AddCommands();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IAccountService, AccountService>();
        }

        public static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AccountCreatedCommand, bool>, AccountCreatedCommandHandler>();
        }

    }
}

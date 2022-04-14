using Account.Microservice.Core.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Account.Microservice.Core.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(IServiceCollection services, IConfiguration configuration) {

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void AddServices(this IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
        }

    }
}

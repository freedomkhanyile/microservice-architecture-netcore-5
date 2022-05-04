using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Microservice.Application;
using Student.Microservice.Persistence.Context;

namespace Student.Microservice.Persistence
{
    public static class DependencyInjection
    {
        public static void AddStudentPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(StudentDbContext).Assembly.FullName)));
            services.AddTransient<IStudentDbContext>(provider => provider.GetRequiredService<StudentDbContext>());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Microservice.Core.Application;

namespace Student.Microservice.Infrustucture
{
    public static class DependencyInjection
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(StudentDbContext).Assembly.FullName)));
            services.AddTransient<IStudentDbContext>(provider => provider.GetRequiredService<StudentDbContext>());

        }

    }
}

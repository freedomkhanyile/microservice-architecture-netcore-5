using Microsoft.EntityFrameworkCore;
using Student.Microservice.Core.Application;

namespace Student.Microservice.Infrustucture
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Core.Domain.Entities.Student> Students { get; set; }
    }
}

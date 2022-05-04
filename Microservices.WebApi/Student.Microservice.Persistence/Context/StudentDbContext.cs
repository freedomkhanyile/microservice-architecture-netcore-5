using Microsoft.EntityFrameworkCore;
using Student.Microservice.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Persistence.Context
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Student> Students { get; set; }
    }
}

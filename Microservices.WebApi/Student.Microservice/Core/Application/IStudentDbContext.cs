using Microsoft.EntityFrameworkCore;
using Entities = Student.Microservice.Core.Domain.Entities;
namespace Student.Microservice.Core.Application
{
    public interface IStudentDbContext
    {
        DbSet<Entities.Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Entities = Student.Microservice.Domain.Entities;
namespace Student.Microservice.Application
{
    public interface IStudentDbContext
    {
        DbSet<Entities.Student> Students { get; set; }

        Task<int> SaveChangesAsync();
    }
}

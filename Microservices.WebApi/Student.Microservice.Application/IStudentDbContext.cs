using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Student.Microservice.Domain.Entities;
namespace Student.Microservice.Application
{
    public interface IStudentDbContext
    {
        DbSet<Entities.Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Entities = Application.Microservice.Core.Domain.Entities;
namespace Application.Microservice.Core.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Application> Applications { get; set; }
        DbSet<Entities.ApplicationResult> ApplicationResults { get; set; }

    }
}

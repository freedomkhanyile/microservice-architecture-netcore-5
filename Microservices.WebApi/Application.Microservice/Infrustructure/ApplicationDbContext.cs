using Application.Microservice.Core.Application;
using Entities = Application.Microservice.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Microservice.Infrustructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Entities.Application> Applications { get; set; }
        public DbSet<Entities.ApplicationResult> ApplicationResults { get; set; }
    }
}

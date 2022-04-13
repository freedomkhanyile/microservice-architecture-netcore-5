using Account.Microservice.Core.Application;
using Account.Microservice.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Microservice.Infrustructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        { }

        public DbSet<Core.Domain.Entities.Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

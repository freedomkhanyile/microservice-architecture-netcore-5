using Account.Microservice.Core.Application;
using Account.Microservice.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Account.Microservice.Infrustructure
{
    public class AcountDbContext : DbContext, IAccountDbContext
    {
        public AcountDbContext(DbContextOptions<AcountDbContext> options)
         : base(options)
        { }

        public DbSet<Core.Domain.Entities.Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }
    }
}

using Microsoft.EntityFrameworkCore;
using Entities = Account.Microservice.Core.Domain.Entities;
namespace Account.Microservice.Core.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Account> Accounts { get; set; }
        DbSet<Entities.AccountRole> AccountRoles { get; set; }
        DbSet<Entities.Role> Roles { get; set; }
    }
}

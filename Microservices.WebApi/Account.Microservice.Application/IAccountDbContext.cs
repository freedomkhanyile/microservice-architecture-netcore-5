using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Account.Microservice.Domain.Entities;
namespace Account.Microservice.Application
{
    public interface IAccountDbContext
    {
        DbSet<Entities.Account> Accounts { get; set; }
        DbSet<Entities.AccountRole> AccountRoles { get; set; }
        DbSet<Entities.Role> Roles { get; set; }

        Task<int> SaveChangesAsync();
    }
}

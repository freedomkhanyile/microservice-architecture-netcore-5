using Account.Microservice.Application;
using Account.Microservice.Application.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Account.Microservice.Domain.Entities;

namespace Account.Microservice.Persistence.Context
{
    public class AccountDbContext : DbContext, IAccountDbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
         : base(options)
        { }

        public DbSet<Entities.Account> Accounts { get; set; }
        public DbSet<Entities.AccountRole> AccountRoles { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }

        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }

         
    }
}

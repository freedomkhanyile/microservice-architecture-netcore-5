using Account.Microservice.Core.Application;
using Entities = Account.Microservice.Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Account.Microservices.Tests.Mocks
{
    public static class MockAccountDbContext
    {
        public static Mock<IAccountDbContext> GetMockedAccountsDb()
        {
            var accounts = new List<Entities.Account>
            {
                new Entities.Account
                {
                    Id = 1,
                    FirstName ="Test",
                    LastName ="Account",
                    Email = "test1@mail.com",
                    Cellphone = "0312457854",
                    CreatedDate = DateTime.Now,
                    CreateUserId = "Test",
                    ModifyDate = DateTime.Now,
                    ModifyUserId = "Test",
                    IsActive = true,
                    StatusId = 1
                },
                 new Entities.Account
                {
                    Id = 2,
                    FirstName ="Test2",
                    LastName ="Account",
                    Email = "test2@mail.com",
                    Cellphone = "011245487451",
                    CreatedDate = DateTime.Now,
                    CreateUserId = "Test",
                    ModifyDate = DateTime.Now,
                    ModifyUserId = "Test",
                    IsActive = true,
                    StatusId = 1
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Entities.Account>>();
            mockSet.As<IQueryable<Entities.Account>>().Setup(m => m.Provider).Returns(accounts.Provider);
            mockSet.As<IQueryable<Entities.Account>>().Setup(m => m.Expression).Returns(accounts.Expression);
            mockSet.As<IQueryable<Entities.Account>>().Setup(m => m.ElementType).Returns(accounts.ElementType);
            mockSet.As<IQueryable<Entities.Account>>().Setup(m => m.GetEnumerator()).Returns(accounts.GetEnumerator());

            var mockDb = new Mock<IAccountDbContext>();
            mockDb.Setup(db => db.Accounts).Returns(mockSet.Object);
            mockDb.Setup(db => db.Accounts.Add(It.IsAny<Entities.Account>())).Returns((Entities.Account account) =>
            {
                accounts.ToList().Add(account);
                return null;              
            });
            return mockDb;

        }
    }
}

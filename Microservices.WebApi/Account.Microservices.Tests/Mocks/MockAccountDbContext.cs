using Account.Microservice.Core.Application;
using Entities = Account.Microservice.Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace Account.Microservices.Tests.Mocks
{
    public static class MockAccountDbContext
    {
        public static Mock<IAccountDbContext> GetMockedAccountsDb()
        {
            var mockDb = new Mock<IAccountDbContext>();


            #region Account Entity Setup
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
                }
                ,new Entities.Account
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
                },new Entities.Account
                {
                    Id = 3,
                    FirstName ="Test3",
                    LastName ="Account",
                    Email = "test3@mail.com",
                    Cellphone = "011245487451",
                    CreatedDate = DateTime.Now,
                    CreateUserId = "Test",
                    ModifyDate = DateTime.Now,
                    ModifyUserId = "Test",
                    IsActive = true,
                    StatusId = 2
                },new Entities.Account
                {
                    Id = 4,
                    FirstName ="Test4",
                    LastName ="Account",
                    Email = "test4@mail.com",
                    Cellphone = "011245487451",
                    CreatedDate = DateTime.Now,
                    CreateUserId = "Test",
                    ModifyDate = DateTime.Now,
                    ModifyUserId = "Test",
                    IsActive = true,
                    StatusId = 3
                }
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Entities.Account>>();

            mockSet.As<IAsyncEnumerable<Entities.Account>>().Setup(x => x.GetAsyncEnumerator(default))
                .Returns(new TestAsyncEnumerator<Entities.Account>(accounts.GetEnumerator()));

            mockSet.As<IQueryable<Entities.Account>>().Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Entities.Account>(accounts.Provider));

            mockSet.As<IQueryable<Entities.Account>>()
                .Setup(m => m.Expression)
                .Returns(accounts.Expression);

            mockSet.As<IQueryable<Entities.Account>>()
                .Setup(m => m.ElementType)
                .Returns(accounts.ElementType);

            mockSet.As<IQueryable<Entities.Account>>()
                .Setup(m => m.GetEnumerator()).Returns(accounts.GetEnumerator());

            mockDb.Setup(db => db.Accounts).Returns(mockSet.Object);
            mockDb.Setup(db => db.Accounts.Add(It.IsAny<Entities.Account>())).Returns((Entities.Account account) =>
            {
                accounts.ToList().Add(account);
                return null;
            });

            #endregion

            #region Role entity setup
            var roles = new List<Entities.Role>
            {
                  new Entities.Role
                    {
                        Id = 1,
                        RoleName = "Admin",
                        Description = "An administrator role normaly does everything",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1,
                    },
                   new Entities.Role
                    {
                        Id = 2,
                        RoleName = "Student",
                        Description = "An student role makes applications to ITS 4.0",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1
                    },
                    new Entities.Role
                    {
                        Id = 3,
                        RoleName = "Clerk",
                        Description =
                            "A clerk is responsible for creating subject and modifying the subjects based on their Faculty Subject Aps requirements",
                        CreatedDate = DateTime.UtcNow.ToLocalTime(),
                        CreateUserId = "builder.seed",
                        ModifyDate = DateTime.UtcNow.ToLocalTime(),
                        ModifyUserId = "builder.seed",
                        StatusId = 1
                    }
            }.AsQueryable();

            var mockRoleSet = new Mock<DbSet<Entities.Role>>();

            mockRoleSet.As<IAsyncEnumerable<Entities.Role>>().Setup(x => x.GetAsyncEnumerator(default))
                .Returns(new TestAsyncEnumerator<Entities.Role>(roles.GetEnumerator()));

            mockRoleSet.As<IQueryable<Entities.Role>>().Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Entities.Role>(roles.Provider));

            mockRoleSet.As<IQueryable<Entities.Role>>()
                .Setup(m => m.Expression)
                .Returns(roles.Expression);

            mockRoleSet.As<IQueryable<Entities.Role>>()
                .Setup(m => m.ElementType)
                .Returns(roles.ElementType);

            mockRoleSet.As<IQueryable<Entities.Role>>()
                .Setup(m => m.GetEnumerator()).Returns(roles.GetEnumerator());

            mockDb.Setup(db => db.Roles).Returns(mockRoleSet.Object);
            mockDb.Setup(db => db.Roles.Add(It.IsAny<Entities.Role>())).Returns((Entities.Role role) =>
            {
                roles.ToList().Add(role);
                return null;
            });

            #endregion

            #region Account Role Setup
            var accountRoles = new List<Entities.AccountRole>
            {
                new Entities.AccountRole
                {
                   Id = 1,
                   AccountId = 1,
                   RoleId = 1,
                   CreatedDate = DateTime.UtcNow.ToLocalTime(),
                   CreateUserId = "builder.seed",
                   ModifyDate = DateTime.UtcNow.ToLocalTime(),
                   ModifyUserId = "builder.seed",
                   StatusId = 1
                },
               new Entities.AccountRole
                {
                   Id = 2,
                   AccountId = 2,
                   RoleId = 2,
                   CreatedDate = DateTime.UtcNow.ToLocalTime(),
                   CreateUserId = "builder.seed",
                   ModifyDate = DateTime.UtcNow.ToLocalTime(),
                   ModifyUserId = "builder.seed",
                   StatusId = 1
                },
                new Entities.AccountRole
                {
                   Id = 3,
                   AccountId = 3,
                   RoleId = 3,
                   CreatedDate = DateTime.UtcNow.ToLocalTime(),
                   CreateUserId = "builder.seed",
                   ModifyDate = DateTime.UtcNow.ToLocalTime(),
                   ModifyUserId = "builder.seed",
                   StatusId = 1
                },
            }.AsQueryable();

            var mockAccountRoleSet = new Mock<DbSet<Entities.AccountRole>>();

            mockAccountRoleSet.As<IAsyncEnumerable<Entities.AccountRole>>().Setup(x => x.GetAsyncEnumerator(default))
                .Returns(new TestAsyncEnumerator<Entities.AccountRole>(accountRoles.GetEnumerator()));

            mockAccountRoleSet.As<IQueryable<Entities.AccountRole>>().Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Entities.AccountRole>(accountRoles.Provider));

            mockAccountRoleSet.As<IQueryable<Entities.AccountRole>>()
                .Setup(m => m.Expression)
                .Returns(accountRoles.Expression);

            mockAccountRoleSet.As<IQueryable<Entities.AccountRole>>()
                .Setup(m => m.ElementType)
                .Returns(accountRoles.ElementType);

            mockAccountRoleSet.As<IQueryable<Entities.AccountRole>>()
                .Setup(m => m.GetEnumerator()).Returns(accountRoles.GetEnumerator());

            mockDb.Setup(db => db.AccountRoles).Returns(mockAccountRoleSet.Object);
            mockDb.Setup(db => db.AccountRoles.Add(It.IsAny<Entities.AccountRole>())).Returns((Entities.AccountRole accountRole) =>
            {
                accountRoles.ToList().Add(accountRole);
                return null;
            });

            #endregion

            return mockDb;
        }
    }

    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider innerQueryProvider;

        internal TestAsyncQueryProvider(IQueryProvider innerQueryProvider)
        {
            this.innerQueryProvider = innerQueryProvider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return this.innerQueryProvider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return this.innerQueryProvider.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = new CancellationToken())
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = ((IQueryProvider)this).Execute(expression);

            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))
                .MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult });
        }
    }
    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }
    }
    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public TestAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }

        public T Current => this.enumerator.Current;

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(() => this.enumerator.Dispose()));
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(this.enumerator.MoveNext());
        }
    }
}

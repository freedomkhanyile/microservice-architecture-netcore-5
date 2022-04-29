
using Account.Microservice.Application;
using Account.Microservice.Application.Features.Queries;
using Account.Microservice.Application.ViewModels;
using Account.Microservices.Tests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Account.Microservices.Tests.FeatureTests.Queries
{
    public class GetAccountByIdRequestHandlerTests
    {
        private readonly Mock<IAccountDbContext> _mockContext;

        public GetAccountByIdRequestHandlerTests()
        {
            _mockContext = MockAccountDbContext.GetMockedAccountsDb();
        }

        [Fact]
        public async Task GetAccountById_ShouldReturnCorrectModel_Test()
        {
            // Arrange 
            var handler = new GetAccountByIdQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAccountByIdQuery { AccountId = 1 }, CancellationToken.None);
            // Assert
            result.ShouldBeOfType<AccountViewModel>();
            result.AccountId.ShouldBe(1);

        }

        [Theory]
        [InlineData(1, "Test","Account", "test1@mail.com", true)]
        [InlineData(2, "Test2", "Account", "test2@mail.com", true)]
        public async Task GetAccountById_ShouldReturnVerifiableData_Test(int accountId, string firstName, string lastName,string email, bool isActive)
        {
            // Arrange 
            var handler = new GetAccountByIdQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAccountByIdQuery { AccountId = accountId }, CancellationToken.None);
            
            // Assert
            result.AccountId.ShouldBe(accountId);
            result.FirstName.ShouldBe(firstName);
            result.LastName.ShouldBe(lastName);
            result.Email.ShouldBe(email);
            result.IsActive.ShouldBe(isActive);
        }



    }
}

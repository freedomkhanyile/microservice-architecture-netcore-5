using Account.Microservice.Core.Application;
using Account.Microservice.Core.Application.Features.Queries;
using Account.Microservice.Core.Application.ViewModels;
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
    public class GetAccountByEmailRequestHandlerTests
    {
        private readonly Mock<IAccountDbContext> _mockContext;

        public GetAccountByEmailRequestHandlerTests()
        {
            _mockContext = MockAccountDbContext.GetMockedAccountsDb();
        }

        [Fact]
        public async Task GetAccountByEmail_ShouldReturnCorrectModel_Test()
        {
            // Arrange
            var handler = new GetAccountByEmailQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAccountByEmailQuery { Email = "test1@mail.com" }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            result.ShouldBeOfType<AccountViewModel>();
        }


        [Theory]
        [InlineData("test1@mail.com", 1, "Test", "Account")]
        [InlineData("test2@mail.com", 2, "Test2", "Account")]
        public async Task GetAccountByEmail_ShouldReturnVerifiableData_Test(string email, int accountId, string firstName, string lastName)
        {
            // Arrange
            var handler = new GetAccountByEmailQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAccountByEmailQuery { Email = email }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            result.Email.ShouldBe(email);
            result.AccountId.ShouldBe(accountId);
            result.FirstName.ShouldBe(firstName);
            result.LastName.ShouldBe(lastName);
        }
    }
}

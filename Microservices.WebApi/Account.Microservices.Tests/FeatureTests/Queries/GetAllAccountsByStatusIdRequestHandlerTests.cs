
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
    public class GetAllAccountsByStatusIdRequestHandlerTests
    {
        private readonly Mock<IAccountDbContext> _mockContext;

        public GetAllAccountsByStatusIdRequestHandlerTests()
        {
            _mockContext = MockAccountDbContext.GetMockedAccountsDb();
        }

        [Fact]
        public async Task GetAllActiveAccountListTest()
        {
            // Arrange
            var handler = new GetAccountsByStatusIdQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAllAccountsByStatusIdQuery { StatusId = 1 }, CancellationToken.None);

            // Assert using Nuget Package:Shouldy
            result.ShouldBeOfType<List<AccountViewModel>>();
            result.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        public async Task GetAllAccountsByStatusIdQueryTest(int statusId, int count)
        {
            // Arrange
            var handler = new GetAccountsByStatusIdQueryHandler(_mockContext.Object);

            // Act
            var result = await handler.Handle(new GetAllAccountsByStatusIdQuery { StatusId = statusId }, CancellationToken.None);

            // Assert : using Nuget PackageL Shouldly
            result.ShouldBeOfType<List<AccountViewModel>>();
            result.Count.ShouldBe(count);
        }



    }
}

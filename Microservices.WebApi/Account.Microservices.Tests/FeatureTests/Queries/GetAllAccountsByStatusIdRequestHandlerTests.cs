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
            var handler = new GetAccountsByStatusIdQueryHandler(_mockContext.Object);
            var result = await handler.Handle(new GetAllAccountsByStatusIdQuery { StatusId = 1}, CancellationToken.None);

            // Assert using Nuget Package:Shouldy
            result.ShouldBeOfType<List<AccountViewModel>>();

        }
    }
}

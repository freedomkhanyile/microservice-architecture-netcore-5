using Account.Microservice.Core.Application;
using Account.Microservice.Core.Application.Features.Queries;
using Account.Microservice.Core.Application.ViewModels;
using Account.Microservices.Tests.Mocks;
using Microsoft.Extensions.Logging;
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
    public class GetAccountRolesByAccountIdRequestHandlerTests
    {
        private readonly Mock<IAccountDbContext> _mockContext;
 
        public GetAccountRolesByAccountIdRequestHandlerTests()
        {
            _mockContext = MockAccountDbContext.GetMockedAccountsDb();
        }

        [Fact]
        public async Task GetAccountRolesByAccountIdTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<GetAllRolesByAccountIdQueryHandler>>();

            var handler = new GetAllRolesByAccountIdQueryHandler(_mockContext.Object, mockLogger.Object);

            // Act  
            var result = await handler.Handle(new GetAllRolesByAccountIdQuery { AccountId = 1 }, CancellationToken.None);

            // Assert : using Nuget Package: Shouldly
            result.ShouldBeOfType<List<RoleViewModel>>();

        }
    }
}

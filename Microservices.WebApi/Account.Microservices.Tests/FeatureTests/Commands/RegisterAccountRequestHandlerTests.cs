
using Account.Microservice.Application;
using Account.Microservice.Application.Features.Commands;
using Account.Microservice.Application.Services;
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

namespace Account.Microservices.Tests.FeatureTests.Commands
{
    public class RegisterAccountRequestHandlerTests
    {
        private readonly Mock<IAccountDbContext> _mockContext;

        public RegisterAccountRequestHandlerTests()
        {
            _mockContext = MockAccountDbContext.GetMockedAccountsDb();
        }

        [Fact]
        public async Task RegisterAccount_ShouldRegisterAndReturnNewAccountId_Tes()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<RegisterAccountCommandHandler>>();
            var mockAccountService = new Mock<IAccountService>();
            var handler = new RegisterAccountCommandHandler(_mockContext.Object, mockLogger.Object, mockAccountService.Object);


            var command = new RegisterAccountCommand
            {
                FirstName = "New",
                LastName = "Test",
                Cellphone = "014545487",
                Email = "newtest@gmail.com",
                Password = "123456",
                IsActive = true,
                RoleName = "Student",
                CreateUserId = "Test",
                ModifyUserId = "Test",
                IsThirdParty = false,
                ThirdPartyProvider = null,
                StatusId = 1
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.ShouldBeGreaterThan(0);
        } 
    }
}

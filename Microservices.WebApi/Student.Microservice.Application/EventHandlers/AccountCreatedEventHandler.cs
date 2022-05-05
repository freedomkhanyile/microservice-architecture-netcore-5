using Domain.Microservices.Core.Bus;
using MediatR;
using Microsoft.Extensions.Logging;
using Student.Microservice.Application.Events;
using Student.Microservice.Application.Helpers.Extensions;
using System.Threading.Tasks;

namespace Student.Microservice.Application.EventHandlers
{
    public class AccountCreatedEventHandler : IEventHandler<AccountCreatedEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountCreatedEventHandler> _logger;
        public AccountCreatedEventHandler(IMediator mediator, ILogger<AccountCreatedEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public AccountCreatedEventHandler() { }
        public async Task Handle(AccountCreatedEvent @event)
        {
            // Handle what business logic is required here.
            var command = @event.ToCommand();
            var accountId = await _mediator.Send(command);
            if (accountId > 0)
            {
                _logger.LogInformation($"INFO: A student with Email: {@event.Email} was created on {nameof(AccountCreatedEvent)} with account id: {@event.AccountId}");
            } else
            {
                _logger.LogError($"ERROR: Processing {nameof(AccountCreatedEvent)} failed");
            }
        }
    }
}

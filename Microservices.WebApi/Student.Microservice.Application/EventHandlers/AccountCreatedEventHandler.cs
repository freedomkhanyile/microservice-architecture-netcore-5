using Domain.Microservices.Core.Bus;
using MediatR;
using Student.Microservice.Application.Events;
using System.Threading.Tasks;

namespace Student.Microservice.Application.EventHandlers
{
    public class AccountCreatedEventHandler : IEventHandler<AccountCreatedEvent>
    {
        private readonly IMediator _mediator;

        public AccountCreatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(AccountCreatedEvent @event)
        {
            // Handle what business logic is required here.

            return Task.CompletedTask;
        }
    }
}

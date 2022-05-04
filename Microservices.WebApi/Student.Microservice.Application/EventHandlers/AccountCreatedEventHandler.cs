using Domain.Microservices.Core.Bus;
using Student.Microservice.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.EventHandlers
{
    public class AccountCreatedEventHandler : IEventHandler<AccountCreatedEvent>
    {
        public AccountCreatedEventHandler() { }
        public Task Handle(AccountCreatedEvent @event)
        {
            // Handle what business logic is required here.

            return Task.CompletedTask;
        }
    }
}

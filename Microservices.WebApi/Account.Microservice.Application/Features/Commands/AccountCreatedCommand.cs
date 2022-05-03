using Account.Microservice.Application.Events;
using Domain.Microservices.Core.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Features.Commands
{
    public class AccountCreatedCommand : CreateAccountCommand
    {
        public AccountCreatedCommand(
            int accountId,
            string firstName,
            string lastName,
            string cellphone,
            string email,
            bool isThirdParty,
            string thirdPartyProvider
            )
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
            Cellphone = cellphone;
            Email = email;
            IsThirdParty = isThirdParty;
            ThirdPartyProvider = thirdPartyProvider;
        }

    }

    public class AccountCreatedCommandHandler : IRequestHandler<AccountCreatedCommand, bool>
    {
        private readonly IEventBus _bus;

        public AccountCreatedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(AccountCreatedCommand command, CancellationToken cancellationToken)
        {
            // You can do whateve is required here per business rule of the service.
            // Publish our event to RabbitMQ
            _bus.Publish(new AccountCreatedEvent(
                command.AccountId,
                command.FirstName,
                command.LastName,
                command.Cellphone,
                command.Email,
                command.IsThirdParty,
                command.ThirdPartyProvider
                ));

            return Task.FromResult(true);
        }
    }

}

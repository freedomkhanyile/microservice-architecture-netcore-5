using Account.Microservice.Application.Features.Commands;
using Account.Microservice.Application.ViewModels;
using Domain.Microservices.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Services
{
    public interface IAccountService
    {
        void PublishAccountCreatedEvent(AccountViewModel model);
    }

    public class AccountService : IAccountService
    {
        private readonly IEventBus _bus;

        public AccountService(IEventBus bus)
        {
            _bus = bus;
        }

        public void PublishAccountCreatedEvent(AccountViewModel model)
        {
            var accountCCreatedEventCommand = new AccountCreatedCommand(
                    model.AccountId,
                    model.FirstName,
                    model.LastName,
                    model.Cellphone,
                    model.Email,
                    model.IsThirdParty,
                    model.ThirdPartyProvider
                );

            _bus.SendCommand(accountCCreatedEventCommand);

        }
    }
}

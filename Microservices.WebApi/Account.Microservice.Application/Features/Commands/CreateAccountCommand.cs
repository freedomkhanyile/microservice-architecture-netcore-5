using Domain.Microservices.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Features.Commands
{
    // Account created event command.
    public abstract class CreateAccountCommand : Command
    {
        // Those who extend (:base 'annotation to your class.cs constructor') it will be able to set it.
        public int AccountId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Cellphone { get; protected set; }
        public string Email { get; protected set; }
        public bool IsThirdParty { get; protected set; }
        public string ThirdPartyProvider { get; protected set; }
    }
}

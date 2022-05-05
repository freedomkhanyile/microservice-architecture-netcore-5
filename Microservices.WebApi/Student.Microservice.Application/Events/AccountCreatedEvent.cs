using Domain.Microservices.Core.Events;

namespace Student.Microservice.Application.Events
{
    public class AccountCreatedEvent : Event
    {
        public int AccountId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Cellphone { get; protected set; }
        public string Email { get; protected set; }
        public bool IsThirdParty { get; protected set; }
        public string ThirdPartyProvider { get; protected set; }
        public AccountCreatedEvent(
            int accountId,
            string firstName,
            string lastName,
            string cellphone,
            string email,
            bool isThirdParty,
            string thirdPartyProvider)
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

}

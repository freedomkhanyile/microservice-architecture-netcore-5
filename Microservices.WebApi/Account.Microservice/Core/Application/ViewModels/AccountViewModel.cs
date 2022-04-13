using System.Collections.Generic;

namespace Account.Microservice.Core.Application.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public AccountViewModel()
        {
            Roles = new List<RoleViewModel>();
        }
    }
}

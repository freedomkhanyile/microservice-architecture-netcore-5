using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Application.ViewModels
{
    public class RegisterAccountViewModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; } 
        [Required]
        public string Cellphone { get; set; }
        public string Password { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
        public string RoleName { get; set; }
        public string CreateUserId { get; set; }
        public string ModifyUserId { get; set; }
        public int StatusId { get; set; }
    }
}

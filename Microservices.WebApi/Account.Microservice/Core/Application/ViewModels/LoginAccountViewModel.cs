using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Core.Application.ViewModels
{
    public class LoginAccountViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

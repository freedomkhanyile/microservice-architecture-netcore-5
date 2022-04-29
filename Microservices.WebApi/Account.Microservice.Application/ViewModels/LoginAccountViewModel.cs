using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Application.ViewModels
{
    public class LoginAccountViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

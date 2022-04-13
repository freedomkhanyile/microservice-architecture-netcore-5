using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Core.Domain.Entities
{
    public class Account : AuditEntity<int>
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Cellphone { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Token { get; set; }
        public bool IsVerified { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
        public string OTP { get; set; }
    }
}

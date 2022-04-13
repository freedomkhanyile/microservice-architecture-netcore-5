using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Core.Domain.Entities
{
    public class AccountRole : AuditEntity<int>
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}

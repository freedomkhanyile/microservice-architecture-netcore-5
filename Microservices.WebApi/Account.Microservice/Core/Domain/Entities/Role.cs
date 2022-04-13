using System.ComponentModel.DataAnnotations;

namespace Account.Microservice.Core.Domain.Entities
{
    public class Role : AuditEntity<int>
    {
        [MaxLength(50)]
        public string RoleName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}

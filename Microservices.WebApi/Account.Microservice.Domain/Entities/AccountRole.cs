using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Microservice.Domain.Entities
{
    public class AccountRole : AuditEntity<int>
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}

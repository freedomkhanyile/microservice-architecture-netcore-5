using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Microservice.Domain.Entities
{
    public class Role : AuditEntity<int>
    {
        [MaxLength(50)]
        public string RoleName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}

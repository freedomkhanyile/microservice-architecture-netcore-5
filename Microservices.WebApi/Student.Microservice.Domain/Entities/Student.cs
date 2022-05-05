using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Domain.Entities
{
    public class Student : AuditEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string Ethnicity { get; set; }
        public string HomeLanguage { get; set; }
     
        public string IdNumber { get; set; }
        [Required]
        public int AccountId { get; set; } // We tie this to the logged in user.
    }
}

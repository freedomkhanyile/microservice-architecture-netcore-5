using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string Ethnicity { get; set; }
        public string HomeLanguage { get; set; }       
        public string IdNumber { get; set; }     
        public int AccountId { get; set; }
    }
}

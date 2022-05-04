using Student.Microservice.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Student.Microservice.Domain.Entities;

namespace Student.Microservice.Application.Helpers.Extensions
{
    public static class StudentExtensions
    {
        public static Entities.Student ToEntity()
        {
            return new Entities.Student
            {

            };
        }

        public static CreateStudentFromAccountCreatedEventViewModel ToModel()
        {
            return new CreateStudentFromAccountCreatedEventViewModel
            {

            };
        }
    }
}

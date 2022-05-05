using Student.Microservice.Application.Events;
using Student.Microservice.Application.Features.Commands;
using Student.Microservice.Application.ViewModel;
using System;
using Entities = Student.Microservice.Domain.Entities;

namespace Student.Microservice.Application.Helpers.Extensions
{
    public static class StudentExtensions
    {
        public static Entities.Student ToEntity(this CreateStudentOnAccountCreatedEventCommand model)
        {
            return new Entities.Student
            {
                AccountId = model.AccountId,
                IdNumber = model.IdNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CellNumber = model.CellNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Ethnicity = model.Ethnicity,
                HomeLanguage = model.HomeLanguage,
                CreateUserId = model.CreateUserId,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = model.ModifyUserId,
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                IsActive = model.IsActive,
                StatusId = model.StatusId

            };
        }

        public static StudentViewModel ToModel(this Entities.Student model)
        {
            return new StudentViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CellNumber = model.CellNumber,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                Ethnicity = model.Ethnicity,
                Gender = model.Gender,
                HomeLanguage = model.HomeLanguage,
                IdNumber = model.IdNumber,
                AccountId = model.AccountId,
            };
        }

        public static CreateStudentOnAccountCreatedEventCommand ToCommand(this AccountCreatedEvent @event)
        {
            return new CreateStudentOnAccountCreatedEventCommand
            {
                AccountId = @event.AccountId,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Email = @event.Email,
                CellNumber = @event.Cellphone,
                CreateUserId = nameof(AccountCreatedEvent),
                ModifyUserId = nameof(AccountCreatedEvent),                
                StatusId = 1
            };
        }
    }
}

using Account.Microservice.Core.Application.ViewModels;
using System;
using Enteties = Account.Microservice.Core.Domain.Entities;
namespace Account.Microservice.Helpers.Extensions
{
    public static class RoleExtensions
    {
        public static Enteties.AccountRole ToEntity(this Enteties.Account account, Enteties.Role role)
        {
            return new Enteties.AccountRole
            {
                AccountId = account.Id,
                RoleId = role.Id,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = account.CreateUserId,
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = account.ModifyUserId,
                IsActive = true,
                StatusId = 1,// Active
            };
        }

        public static RoleViewModel ToModel(this Enteties.Role model)
        {
            return new RoleViewModel
            {
                Id = model.Id,
                RoleName = model.RoleName,
                Description = model.Description
            };
        }
    }
}

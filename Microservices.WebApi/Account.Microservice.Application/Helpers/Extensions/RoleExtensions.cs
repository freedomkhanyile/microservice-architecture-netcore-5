
using Account.Microservice.Application.ViewModels;
using System;
using Entities = Account.Microservice.Domain.Entities;
namespace Account.Microservice.Application.Helpers.Extensions
{
    public static class RoleExtensions
    {
        public static Entities.AccountRole ToEntity(this Entities.Account account, Entities.Role role)
        {
            return new Entities.AccountRole
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

        public static RoleViewModel ToModel(this Entities.Role model)
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

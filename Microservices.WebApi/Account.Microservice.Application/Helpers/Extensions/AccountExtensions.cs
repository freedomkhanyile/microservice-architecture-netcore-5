using Account.Microservice.Application.Features.Commands;
using Account.Microservice.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enteties = Account.Microservice.Domain.Entities;

namespace Account.Microservice.Application.Helpers.Extensions
{
    public static class AccountExtensions
    {
        public static AccountViewModel ToModel(this Enteties.Account account)
        {
            return new AccountViewModel
            {
                AccountId = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Cellphone = account.Cellphone,
                Email = account.Email,
                IsActive = account.IsActive,
                IsThirdParty = account.IsThirdParty,
                ThirdPartyProvider = account.ThirdPartyProvider,
                IsVerified = account.IsVerified,
                Token = account.Token
            };
        }

        public static Enteties.Account ToEntity(this RegisterAccountCommand model)
        {
            return new Enteties.Account
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Cellphone = model.Cellphone,
                Email = model.Email,
                HashedPassword = model.PasswordHash,
                IsActive = model.IsActive,
                OTP = model.OTP,
                IsThirdParty = model.IsThirdParty,
                ThirdPartyProvider = model.ThirdPartyProvider,
                CreateUserId = model.CreateUserId,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = model.ModifyUserId,
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                StatusId = model.StatusId
            };
        }

        public static LoginAccountCommand ToCommand(this LoginAccountViewModel model)
        {
            return new LoginAccountCommand
            {
                Email = model.Username,
                Password = model.Password
            };
        }

        public static RegisterAccountCommand ToCommand(this RegisterAccountViewModel model)
        {
            return new RegisterAccountCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Cellphone = model.Cellphone,
                Email = model.Email,
                Password = model.Password,
                RoleName = model.RoleName,
                IsThirdParty = model.IsThirdParty,
                ThirdPartyProvider = model.ThirdPartyProvider,
                CreateUserId = model.CreateUserId,
                ModifyUserId = model.ModifyUserId,
                StatusId = model.StatusId
            };
        }
    }
}


using Account.Microservice.Application.Helpers.Exceptions;
using Account.Microservice.Application.Helpers.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Account.Microservice.Application.Features.Commands
{
    public class RegisterAccountCommand : IRequest<int>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Cellphone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public bool IsThirdParty { get; set; }
        public string ThirdPartyProvider { get; set; }
        public string RoleName { get; set; }
        public string OTP { get; set; }
        [MaxLength(256)]
        public string CreateUserId { get; set; }
        [MaxLength(256)]
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; } = true;
        public int StatusId { get; set; }
    }

    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, int>
    {
        private readonly IAccountDbContext _context;
        private readonly Random _random = new Random();
        private readonly ILogger<RegisterAccountCommandHandler> _logger;
        public RegisterAccountCommandHandler(IAccountDbContext dbContext, ILogger<RegisterAccountCommandHandler> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public async Task<int> Handle(RegisterAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // 1 Get a role
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName.ToLower() == command.RoleName.ToLower());
                if (role == null)
                {
                    _logger.LogError("{0} : Did not return role for {1} : {2}", nameof(RegisterAccountCommand), command.RoleName, DateTime.UtcNow.ToLocalTime());
                    return default;
                }

                // Hash password using Bcrypt https://code.google.com/archive/p/bcryptnet/
                command.PasswordHash = command.Password != null ? BC.HashPassword(command.Password) : null;

                // Generate otp
                command.OTP = _random.Next().ToString().Substring(0, 4);

                var accountToCreate = command.ToEntity();

                await _context.Accounts.AddAsync(accountToCreate);
                await _context.SaveChangesAsync();

                if(accountToCreate.Id > 0)
                {
                    // Let us allocate this account to a role
                    var accountRoleToCreate = accountToCreate.ToEntity(role);
                    await _context.AccountRoles.AddAsync(accountRoleToCreate);
                    await _context.SaveChangesAsync();
                }

                return accountToCreate.Id;
            }
            catch (Exception ex)
            {
                throw new AppException($"{nameof(RegisterAccountCommand)} : {ex.Message}");
            }
        }
    }
}

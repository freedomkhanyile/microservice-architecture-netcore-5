
using Account.Microservice.Application.Helpers.Exceptions;
using Account.Microservice.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Features.Commands
{
    public class LoginAccountCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, int>
    {
        private readonly IAccountDbContext _context;
        private readonly IEncryptionService _encryptionService;
        public LoginAccountCommandHandler(IAccountDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<int> Handle(LoginAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == command.Email);

                if (account == null) return default;

                // If Google and any other third party sign-ins we dont store passwords.
                if(command.Password != null) 
                    if(!_encryptionService.IsValidPassword(command.Password, account.HashedPassword))
                        return default;

                return account.Id;
            }
            catch (System.Exception ex)
            {
                throw new AppException($"{nameof(LoginAccountCommand)} : {ex.Message}");
            }
        }
    }
}

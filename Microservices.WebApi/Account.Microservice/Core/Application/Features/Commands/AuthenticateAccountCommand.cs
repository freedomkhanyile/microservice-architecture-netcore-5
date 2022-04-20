using Account.Microservice.Core.Application.Services;
using Account.Microservice.Filters.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArgumentNullException = Account.Microservice.Filters.Exceptions.ArgumentNullException;

namespace Account.Microservice.Core.Application.Features.Commands
{
    public class AuthenticateAccountCommand : IRequest<int>
    {
        public int AccountId { get; set; }
    }

    public class AuthenticateAccountCommandHandler : IRequestHandler<AuthenticateAccountCommand, int>
    {
        private readonly IAccountDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthenticateAccountCommandHandler> _logger;
        public AuthenticateAccountCommandHandler(IAccountDbContext context, ITokenService tokenService, ILogger<AuthenticateAccountCommandHandler> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<int> Handle(AuthenticateAccountCommand command, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == command.AccountId);

            if (account == null) return default;

            try
            {
                // Get Account roles 
                var accountRoles = await _context.AccountRoles.Where(x => x.AccountId == account.Id)
                    .AsNoTracking()
                    .ToListAsync();

                if(accountRoles.Any())
                {
                    var roleIds = accountRoles.Select(x => x.RoleId).ToList();

                    // Now get all role entities belonging to this account.
                    var roles = await _context.Roles
                        .Where(x => roleIds.Contains(x.Id))
                        .Select(x => x.RoleName)
                        .ToArrayAsync();

                    // Now let us create a token with claims

                    //1. The expiry period
                    var expiryPeriod = DateTime.Now.ToLocalTime() + TokenAuthOption.ExpiresSpan;

                    var token = _tokenService.BuildToken(account, roles, expiryPeriod);
                    if (token == null) throw new BadRequestException($"{nameof(AuthenticateAccountCommand)} :Failed to generate token");

                    // Update account token
                    account.Token = token;
                    _context.Accounts.Update(account);
                    await _context.SaveChangesAsync();
                    return account.Id;
                } else
                {
                    throw new ArgumentNullException($"{nameof(AuthenticateAccountCommand)}: Failed to get roles for account : {command.AccountId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {0}", ex);
                throw new AppException(ex.Message);
            }       
        }
    }
}

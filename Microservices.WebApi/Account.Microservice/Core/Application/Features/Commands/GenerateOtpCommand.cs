using Account.Microservice.Filters.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Core.Application.Features.Commands
{
    public class GenerateOtpCommand : IRequest<int>
    {
        public string Email { get; set; }
    }

    public class GenerateOtpCommandHandler : IRequestHandler<GenerateOtpCommand, int>
    {
        private readonly IAccountDbContext _context;
        private readonly Random _random = new Random();
        public GenerateOtpCommandHandler(IAccountDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GenerateOtpCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == command.Email);
                if (account == null) return default;

                // Now lets generate the otp
                var otp = _random.Next().ToString().Substring(0, 4);
                account.OTP = otp;
                account.IsVerified = false;

                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
                return account.Id;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }

}

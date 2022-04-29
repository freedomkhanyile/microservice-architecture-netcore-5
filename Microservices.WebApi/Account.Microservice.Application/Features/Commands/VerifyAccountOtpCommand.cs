using Account.Microservice.Application.Helpers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Account.Microservice.Application.Features.Commands
{
    public class VerifyAccountOtpCommand : IRequest<int>
    {
        public string OTP { get; set; }
    }

    public class VerifyAccountOtpCommandHandler : IRequestHandler<VerifyAccountOtpCommand, int>
    {
        private readonly IAccountDbContext _context;

        public VerifyAccountOtpCommandHandler(IAccountDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(VerifyAccountOtpCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.OTP != null && x.OTP == command.OTP);
                if (account == null) return default;
                account.IsVerified = true;
                account.OTP = null;
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
                return account.Id;
            }
            catch (Exception ex)
            {
                throw new AppException($"{nameof(VerifyAccountOtpCommand)} : {ex.Message} on {DateTime.UtcNow.ToLocalTime()}");
            }
        }
    }
}

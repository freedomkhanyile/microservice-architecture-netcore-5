using Account.Microservice.Core.Application.ViewModels;
using Account.Microservice.Helpers.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Core.Application.Features.Queries
{
    public class GetAccountByEmailQuery : IRequest<AccountViewModel>
    {
        public string Email { get; set; }
    }

    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, AccountViewModel>
    {
        private readonly IAccountDbContext _context;

        public GetAccountByEmailQueryHandler(IAccountDbContext context)
        {
            _context = context;
        }
        public async Task<AccountViewModel> Handle(GetAccountByEmailQuery query, CancellationToken cancellationToken)
        {
            // Get account
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == query.Email);
            if (account == null) return null;
            return account.ToModel();
        }
    }
}

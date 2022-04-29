using Account.Microservice.Application.Helpers.Exceptions;
using Account.Microservice.Application.Helpers.Extensions;
using Account.Microservice.Application.ViewModels;
 
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Features.Queries
{
    public class GetAllAccountsByStatusIdQuery : IRequest<List<AccountViewModel>>
    {
        public int StatusId { get; set; }
    }

    public class GetAccountsByStatusIdQueryHandler : IRequestHandler<GetAllAccountsByStatusIdQuery, List<AccountViewModel>>
    {
        private readonly IAccountDbContext _context;

        public GetAccountsByStatusIdQueryHandler(IAccountDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountViewModel>> Handle(GetAllAccountsByStatusIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var accounts = await _context.Accounts
               .Where(x => x.StatusId == query.StatusId)
               .AsNoTracking()
               .ToListAsync();

                if (accounts == null) return null;
                if (accounts.Any())
                    return accounts.Select(x => x.ToModel()).ToList();
                return new List<AccountViewModel>();
            }
            catch (System.Exception ex)
            {
                throw new AppException($"ERROR: {ex.Message}");
            }

        }
    }
}

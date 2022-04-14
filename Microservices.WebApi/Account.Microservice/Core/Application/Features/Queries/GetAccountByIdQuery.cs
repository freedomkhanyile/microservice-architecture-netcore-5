﻿using Account.Microservice.Core.Application.ViewModels;
using Account.Microservice.Helpers.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Core.Application.Features.Queries
{
    public class GetAccountByIdQuery : IRequest<AccountViewModel>
    {
        public int AccountId { get; set; }
    }

    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountViewModel>
    {
        private readonly IAccountDbContext _context;
        public GetAccountByIdQueryHandler(IAccountDbContext context)
        {
            _context = context;
        }

        public async Task<AccountViewModel> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == query.AccountId);
            if(account == null) return null;
            return account.ToModel();
        }
    }
}

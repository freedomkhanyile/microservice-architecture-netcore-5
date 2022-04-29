using Account.Microservice.Application.Helpers.Exceptions;
using Account.Microservice.Application.Helpers.Extensions;
using Account.Microservice.Application.ViewModels;
 
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Application.Features.Queries
{
    public class GetAllRolesByAccountIdQuery : IRequest<List<RoleViewModel>>
    {
        public int AccountId { get; set; }

    }
    public class GetAllRolesByAccountIdQueryHandler : IRequestHandler<GetAllRolesByAccountIdQuery, List<RoleViewModel>>
    {
        private readonly IAccountDbContext _context;
        private readonly ILogger<GetAllRolesByAccountIdQueryHandler> _logger;
        public GetAllRolesByAccountIdQueryHandler(IAccountDbContext context, ILogger<GetAllRolesByAccountIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<RoleViewModel>> Handle(GetAllRolesByAccountIdQuery query, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == query.AccountId);
            if (account == null) return null;

            try
            {
                var roleIds = await _context.AccountRoles.Where(x => x.AccountId == query.AccountId)
                    .AsNoTracking()
                    .Select(x => x.RoleId).ToListAsync();

                var roleList = new List<RoleViewModel>();

                if (roleIds.Any())
                {
                    var roles = await _context.Roles                        
                        .Where(x => roleIds.Contains(x.Id))
                        .ToArrayAsync();

                    if (roles.Any())
                    {
                        return roles.Select(x => x.ToModel()).ToList();
                    }
                    else
                    {
                        _logger.LogError("{0} : Did not return any roles from RoleIds collection for account : {1} on {2}", nameof(GetAllRolesByAccountIdQuery), query.AccountId, DateTime.UtcNow.ToLocalTime());
                        return new List<RoleViewModel>(); 
                    }

                    return roleList;
                }
                else
                {
                    _logger.LogError("{0} : Did not return any RoleIds for account : {1} on {2}", nameof(GetAllRolesByAccountIdQuery), query.AccountId, DateTime.UtcNow.ToLocalTime());
                    return new List<RoleViewModel>();
                }
            }
            catch (Exception ex)
            {
                throw new AppException($"{nameof(GetAllRolesByAccountIdQuery)} : {ex.Message} on : {DateTime.UtcNow.ToLocalTime()}");
            }
        }
    }
}

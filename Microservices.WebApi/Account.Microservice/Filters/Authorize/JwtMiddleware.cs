using Account.Microservice.Core.Application.Features.Queries;
using Account.Microservice.Core.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Filters.Authorize
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IMediator _mediator, ITokenService tokenService)
        {
            // Get token from the front-end
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var accountId = tokenService.ValidateToken(token);
            if (accountId != null)
            {
                // attach account to context on successfully validation
                context.Items["User"] = await _mediator.Send(new GetAccountByIdQuery { AccountId = (int)accountId });
                // attach roles to account
                context.Items["Roles"] = await _mediator.Send(new GetAllRolesByAccountIdQuery { AccountId = (int)accountId });
            }
            await _next(context);
        }
    }
}

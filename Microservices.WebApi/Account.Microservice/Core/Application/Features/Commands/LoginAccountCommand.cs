using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Microservice.Core.Application.Features.Commands
{
    public class LoginAccountCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, int>
    {
        public Task<int> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

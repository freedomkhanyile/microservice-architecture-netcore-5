using Account.Microservice.Application.Features.Commands;
using Account.Microservice.Application.Features.Queries;
using Account.Microservice.Application.Helpers.Extensions;
using Account.Microservice.Application.ViewModels;
using Account.Microservice.Filters.Authorize;

using MediatR;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Account.Microservice.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        private IHostingEnvironment _env;
        public AccountController(ILogger<AccountController> logger, IMediator mediator, IHostingEnvironment env)
        {
            _logger = logger;
            _mediator = mediator;
            _env = env;
        }

        /// <summary>
        /// Login user with email and password
        /// </summary>
        /// <param name="LoginAccountViewModel"></param>
        /// <returns>Authenticatted Account Model</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AccountViewModel>> LoginAsync([FromBody] LoginAccountViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var command = model.ToCommand();

            var accountId = await _mediator.Send(command);
            if (accountId == 0) return Ok(new { Error = "Email or password is invalid" });

            if (await _mediator.Send(new AuthenticateAccountCommand { AccountId = accountId }) == 0) return BadRequest("Failed to Authenticate");

            var account = await _mediator.Send(new GetAccountByIdQuery { AccountId = accountId });
            if (account == null) return Ok(new { Error = "Email or password is invalid" });

            if (!account.IsVerified)
            {
                var message = new MessageViewModel
                {
                    Subject = "Unverified account!",
                    Title = "Uh Oh",
                    Message = "Your account has not been verified, please enter otp or click resend pin to request a new pin.",
                    CtaLabel = "Continue",
                    CtaLink = "/verify",
                    Class = "warning",
                    Icon = "warning"
                };

                return Ok(message);
            }

            // Get account roles.
            var roles = await _mediator.Send(new GetAllRolesByAccountIdQuery { AccountId = accountId });
            account.Roles = roles;

            return Ok(account);
        }

        /// <summary>
        ///  Register a new account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<MessageViewModel>> RegisterAsync([FromBody] RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingUser = await _mediator.Send(new GetAccountByEmailQuery { Email = model.Email });

            if (existingUser != null && existingUser.Email == model.Email)
                return Ok(new MessageViewModel
                {
                    Subject = "An error occured!",
                    Title = "Uh oh",
                    Message = "This account is already in use, please sign in",
                    CtaLabel = "Try again",
                    Class = "warning",
                    Icon = "warning"
                });

            var command = model.ToCommand();
            var accountId = await _mediator.Send(command);

            if (accountId == 0) return Ok(new MessageViewModel
            {
                Subject = "An error occured!",
                Title = "Oops",
                Message = "Something went wrong. Please try again",
                CtaLabel = "Try again",
                Class = "danger",
                Icon = "close"
            });

            // TODO: Send OTP Email

            return Ok(new MessageViewModel
            {
                Subject = "Request successfully executed",
                Title = "Congratulations",
                Message = "Your account was registered successfully. Please verify OTP before signing in",
                CtaLabel = "Continue",
                Class = "success",
                CtaLink = "/sign-in",
                Icon = "check"
            });
        }
    }
}

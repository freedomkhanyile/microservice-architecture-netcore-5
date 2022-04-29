using Account.Microservice.Application.Helpers.Constants;
using Account.Microservice.Application.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Account.Microservice.Filters.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<RoleEnum> _roles;

        public AuthorizeAttribute(params RoleEnum[] roles)
        {
            _roles = roles ?? new RoleEnum[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var account = (AccountViewModel)context.HttpContext.Items["User"];

            if (account == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            var roles = (List<RoleViewModel>)context.HttpContext.Items["Roles"];

            var hasRole = roles.Any(x =>
                 x.RoleName == RoleEnum.Admin.ToString());

            if (account == null || (_roles.Any() && !hasRole))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

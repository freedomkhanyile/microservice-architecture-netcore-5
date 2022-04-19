using System;

namespace Account.Microservice.Filters.Authorize
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {

    }
}

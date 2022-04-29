using System;

namespace Account.Microservice.Application.Helpers.Exceptions
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException(string message) : base(message)
        {
        }
    }
}

using System;

namespace Account.Microservice.Filters.Exceptions
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException(string message) : base(message)
        {
        }
    }
}

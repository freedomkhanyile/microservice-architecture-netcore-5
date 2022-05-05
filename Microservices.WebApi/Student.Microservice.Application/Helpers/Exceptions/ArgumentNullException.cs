using System;

namespace Student.Microservice.Application.Helpers.Exceptions
{
    public class ArgumentNullException : Exception
    {
        public ArgumentNullException(string message) : base(message)
        {
        }
    }
}

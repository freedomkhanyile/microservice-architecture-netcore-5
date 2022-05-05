using System;
using System.Globalization;

namespace Student.Microservice.Application.Helpers.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, params object[] args)
          : base(string.Format(CultureInfo.CurrentCulture, message, args))
        { }
    }
}

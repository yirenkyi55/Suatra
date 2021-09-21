using System;

namespace Suatra.Application.Common.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}

using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Suatra.Application.Common.Contracts.Services;

namespace Suatra.Infrastructure.Services
{
    public class LoggedInUserService: ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoggedInUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public string GetLoggedInUserEmail()
        {
            return _contextAccessor
                .HttpContext?.User?
                .Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
    }
}
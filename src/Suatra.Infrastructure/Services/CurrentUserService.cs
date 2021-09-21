using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Suatra.Application.Common.Contracts.Services;

namespace Suatra.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _context;

        public CurrentUserService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public string GetLoggedInUserEmail()
        {
            return _context.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    
        }

     
    }
}
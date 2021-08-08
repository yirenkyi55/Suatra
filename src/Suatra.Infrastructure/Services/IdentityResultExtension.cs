using System.Linq;
using Microsoft.AspNetCore.Identity;
using Suatra.Application.Common.Models;

namespace Suatra.Infrastructure.Services
{
    public static class IdentityResultExtension
    {
        public static Result ToAppResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(error => error.Description));
        }
    }
}
using System.Security.Claims;
using Suatra.Domain.Entities;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

        string GenerateRefreshToken();

        ClaimsPrincipal GeneratePrincipalFromExpiredToken(string token);
    }
}
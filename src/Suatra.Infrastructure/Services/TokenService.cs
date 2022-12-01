using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Services
{
    public class TokenService:ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public TokenService(IConfiguration configuration, 
            TokenValidationParameters tokenValidationParameters)
        {
            _configuration = configuration;
            _tokenValidationParameters = tokenValidationParameters;
        }
        
        public string GenerateAccessToken(User user)
        {
            // Generate claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            
            // add more roles over here
            
            // Get the key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Application:Key"]));
            //Generate a signing credentials
            var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = signingCredential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var rng = RandomNumberGenerator.Create();
            var salt = new byte[32];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public ClaimsPrincipal GeneratePrincipalFromExpiredToken(string token)
        {
            _tokenValidationParameters.ValidateLifetime = false;
            
            //Generates a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var securityToken);

            //We check if the security token is of type JwtSecurityToken
            //or the algorithm specified is the one used in creating the token
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            //We can now return the principal, using this principal,
            //we can access the users info from the principal claims
            return principal;
        }
    }
}
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Suatra.Domain.Entities;
using Suatra.Infrastructure.Persistence;

namespace Suatra.API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add .Net Core Identity Services
            var passwordOptions = new PasswordOptions
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireNonAlphanumeric = false,
                RequireUppercase = true,
                RequireLowercase = true
            };
            var builder =  services.AddIdentityCore<User>(options =>
            {
                options.Password = passwordOptions;
            });
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<User>>();
   
            
            // Add .Net Core Authentication Services using Jwt
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Application:Key"]));
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey =  true,
                ValidateIssuer =  false,
                ValidateAudience = false,
                IssuerSigningKey = key,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                });
            
            // Add .Net Core Authorization services
            services.AddAuthorization();
            
            services.AddSingleton(tokenValidationParameters);
            services.AddSingleton(passwordOptions);
            
            return services;
        }
    }
}
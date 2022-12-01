using System.Linq;

using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

using Suatra.API.Helpers.Filters;
using Suatra.Application.Features.Courses.Dto.Requests.Validators;

namespace Suatra.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {

                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var executingContext = context as ActionExecutingContext;
                    //if there are ModelState errors and all keys are correctly found, we instruct
                    //the system to deal with 422 Validation Errors and Not Bad Request
                    if (context.ModelState.ErrorCount > 0 &&
                    executingContext?.ActionArguments.Count ==
                    context.ActionDescriptor.Parameters.Count)
                    {
                        var errors = context.ModelState
                        .Where(e => e.Value.Errors.Any())
                        .SelectMany(e => e.Value.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToArray();

                        return new UnprocessableEntityObjectResult(new
                        {
                            errors,
                            statusCode = 422,
                            message = "One or more validation errors occurred"
                        });
                    }

                    // We return 400 bad request by default
                    return new BadRequestObjectResult(context.ModelState);
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => policy.WithOrigins("http://localhost:4200")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });
            return services;
        }
    }
}
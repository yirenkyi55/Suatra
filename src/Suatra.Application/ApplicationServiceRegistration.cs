using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Suatra.Application.Features.Categories.Dto.Requests;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Suatra.Application.Common.Models;

namespace Suatra.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Configure<Settings>(configuration.GetSection("Settings"));
            return services;
        }


        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(c =>
                {
                    c.RegisterValidatorsFromAssemblyContaining<CreateCategoryRequest>();
                }
              );

            return builder;
        }
    }
}

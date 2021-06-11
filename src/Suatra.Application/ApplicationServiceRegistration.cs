using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Suatra.Application.Features.Categories.Dto.Requests;
using System.Reflection;

namespace Suatra.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

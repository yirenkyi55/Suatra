using System.Reflection;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Suatra.Application.Common.Configuration;
using Suatra.Application.Common.Models;
using Suatra.Application.Features.Categories.Dto.Requests.Validators;

namespace Suatra.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Configure<Settings>(configuration.GetSection("Settings"));
            services.Configure<ClientSettingOptions>(configuration.GetSection(nameof(ClientSettingOptions)));
            services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>();
            return services;
        }
    }
}
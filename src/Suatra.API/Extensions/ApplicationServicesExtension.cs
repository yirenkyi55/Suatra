using Microsoft.Extensions.DependencyInjection;
using Suatra.Application;

namespace Suatra.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllers().AddValidation();

            return services;
        }
    }
}

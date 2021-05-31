using Microsoft.Extensions.DependencyInjection;

namespace Suatra.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}

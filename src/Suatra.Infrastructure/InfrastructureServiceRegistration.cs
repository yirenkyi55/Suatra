using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Infrastructure.Persistence;
using Suatra.Infrastructure.Persistence.Repositories;
using Suatra.Infrastructure.Services;

namespace Suatra.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IDatabaseTransaction, DatabaseTransaction>();

            // Register mailkit as a service
            services.AddMailKit(option =>
            {
                option.UseMailKit(configuration.GetSection("Email").Get<MailKitOptions>());
            });
            
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ILoggedInUserService, LoggedInUserService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IApplicationMailService, ApplicationMailService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IMailService, MailkitMailService>();
            services.AddTransient<ITemplateService, TemplateService>();
            services.AddTransient<IUrlService, UrlService>();

            return services;
        }
    }
}

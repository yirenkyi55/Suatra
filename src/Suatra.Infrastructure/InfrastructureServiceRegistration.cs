using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Infrastructure.Persistence;
using Suatra.Infrastructure.Persistence.Repositories;

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

            return services;
        }
    }
}

using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Suatra.Application.Common.Statics;

namespace Suatra.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void UseSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var context = services
                .GetRequiredService<ApplicationDbContext>();

            var loggerFactory = services
                .GetRequiredService<ILoggerFactory>();

            ApplicationLogging.LoggerFactory = loggerFactory;

            var log = ApplicationLogging.CreateLogger("SeedData");

            try
            {
                if (context.Database.GetPendingMigrations().Any())
                    context.Database.Migrate();

                // Perform seeding of data
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
            }
        }
    }
}
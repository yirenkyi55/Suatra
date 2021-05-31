using Microsoft.EntityFrameworkCore;
using Suatra.Infrastructure.Persistence;
using System;

namespace Suatra.Fixtures
{
    public class ApplicationDbContextFactory
    {
        public readonly TestApplicationDbContext Context;

        public ApplicationDbContextFactory()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging().Options;

            EnsureCreation(dbContextOptions);

            Context = new TestApplicationDbContext(dbContextOptions);

        }

        private static void EnsureCreation(DbContextOptions<ApplicationDbContext> options)
        {
            using var context = new TestApplicationDbContext(options);
            context.Database.EnsureCreated();
        }
    }
}

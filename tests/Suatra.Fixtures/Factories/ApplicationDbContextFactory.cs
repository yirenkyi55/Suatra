using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Domain.Entities;
using Suatra.Infrastructure.Persistence;

namespace Suatra.Fixtures.Factories
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
            Context = new TestApplicationDbContext(dbContextOptions, GetFakeUserService().Object);

        }

        private static Mock<ICurrentUserService> GetFakeUserService()
        {
            var testUser = new User()
            {
                Email = "testuser@email.com",
                Id = Guid.NewGuid().ToString(),
                UserName = "testUser@email.com"
            };

            var fakeCurrentUserService = new Mock<ICurrentUserService>();
            fakeCurrentUserService.Setup(x => x.GetLoggedInUserEmail())
                .Returns(() => testUser.Email);
            
            return fakeCurrentUserService;
        }

        private static void EnsureCreation(DbContextOptions<ApplicationDbContext> options)
        {
            using var context = new TestApplicationDbContext(options,GetFakeUserService().Object);
            context.Database.EnsureCreated();
        }
    }
}

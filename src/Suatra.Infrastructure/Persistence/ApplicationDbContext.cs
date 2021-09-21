using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;
using Suatra.Infrastructure.Persistence.Repositories;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Domain.Common;

namespace Suatra.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>, IUnitOfWork
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseSection> CourseSections { get; set; }

        public DbSet<SectionContent> SectionContents { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Category> Categories { get; set; }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                _currentUserService.GetLoggedInUserEmail();
            }
            catch (Exception exception)
            {
                return base.SaveChangesAsync(cancellationToken);
            }
        
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _currentUserService.GetLoggedInUserEmail();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _currentUserService.GetLoggedInUserEmail();
                        break;
                }
            }
        
            return base.SaveChangesAsync(cancellationToken);
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(this);
        }
    }
}
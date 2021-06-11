using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Domain.Entities;
using Suatra.Infrastructure.Persistence.Repositories;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>, IUnitOfWork
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseAuthor> CourseAuthors { get; set; }

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

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(this);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Suatra.Domain.Entities;
using Suatra.Fixtures.Extensions;
using Suatra.Infrastructure.Persistence;

namespace Suatra.Fixtures
{
    public class TestApplicationDbContext : ApplicationDbContext
    {
        public TestApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Perform some database seeding
            builder.Seed<User>("./SeedData/users.json");
            builder.Seed<Category>("./SeedData.categories.json");
            builder.Seed<Topic>("./SeedData/topics.json");
            builder.Seed<Course>("./SeedData/courses.json");
            builder.Seed<CourseSection>("./SeedData/sections.json");
            builder.Seed<CourseAuthor>("./SeedData/courseAuthors.json");

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class CourseSectionConfiguration : IEntityTypeConfiguration<CourseSection>
    {
        public void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasOne(x => x.Course).WithMany(c => c.CourseSections)
                .HasForeignKey(x => x.CourseId);
        }
    }
}

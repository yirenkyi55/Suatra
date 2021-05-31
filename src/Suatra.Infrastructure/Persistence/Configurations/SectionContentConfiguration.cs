using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class SectionContentConfiguration : IEntityTypeConfiguration<SectionContent>
    {
        public void Configure(EntityTypeBuilder<SectionContent> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ContentUri).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.CourseSection)
                .WithMany(cs => cs.SectionContents)
                .HasForeignKey(x => x.CourseSectionId);
        }
    }
}

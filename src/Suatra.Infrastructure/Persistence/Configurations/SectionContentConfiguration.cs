using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Suatra.Application.Common.Constants;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class SectionContentConfiguration : IEntityTypeConfiguration<SectionContent>
    {
        public void Configure(EntityTypeBuilder<SectionContent> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxLengthOf128);
            builder.Property(x => x.ContentUri).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxLengthOf256).IsUnicode(false);
            builder.HasOne(x => x.CourseSection)
                .WithMany(cs => cs.SectionContents)
                .HasForeignKey(x => x.CourseSectionId);
        }
    }
}

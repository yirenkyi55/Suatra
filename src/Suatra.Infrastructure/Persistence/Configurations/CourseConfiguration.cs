using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;
using System;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.About).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Expectations).IsRequired();
            builder.Property(x => x.Requirements).IsRequired();
            builder.Property(x => x.IntendedAudience).HasMaxLength(500);
            builder.Property(x => x.CoverPhotoUri).HasMaxLength(150);
            builder.Property(x => x.CoverVideoUri).HasMaxLength(150);
            builder.HasOne(x => x.Topic).
                WithMany(t => t.Courses)
                .HasForeignKey(x => x.TopicId);
            builder.HasOne(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId);

        }
    }
}

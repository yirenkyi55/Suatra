using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;
using System;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class CourseAuthorConfiguration : IEntityTypeConfiguration<CourseAuthor>
    {
        public void Configure(EntityTypeBuilder<CourseAuthor> builder)
        {
            builder.HasOne(ca => ca.Course).WithMany(c => c.CourseAuthors)
                .HasForeignKey(ca => ca.CourseId);

            builder.HasOne(ca => ca.User)
                .WithMany(u => u.CourseAuthors)
                .HasForeignKey(ca => ca.UserId);
        }
    }
}

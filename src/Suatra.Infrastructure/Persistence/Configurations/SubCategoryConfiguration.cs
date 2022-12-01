using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Suatra.Application.Common.Constants;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(EntityConfigurationConstants.MaxLengthOf128);

            builder.HasOne(x => x.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Topics)
                .WithOne(t => t.SubCategory)
                .HasForeignKey(t => t.SubCategoryId);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
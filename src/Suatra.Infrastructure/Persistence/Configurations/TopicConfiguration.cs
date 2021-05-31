using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.HasOne(x => x.Category).WithMany(cat => cat.Topics).HasForeignKey(x => x.CategoryId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Bio).HasMaxLength(1000);
            builder.Property(u => u.OtherName).HasMaxLength(150);
            builder.Property(u => u.PhotoUri).HasMaxLength(150);
           
        }
    }
}

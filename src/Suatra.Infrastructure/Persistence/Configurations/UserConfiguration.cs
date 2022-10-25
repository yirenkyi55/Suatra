using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Suatra.Application.Common.Constants;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxLengthOf128);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxLengthOf128);
            builder.Property(u => u.Bio).HasMaxLength(EntityConfigurationConstants.MaxLengthOf512);
            builder.Property(u => u.OtherName).HasMaxLength(EntityConfigurationConstants.MaxLengthOf64);
            builder.Property(u => u.PhotoUri).HasMaxLength(EntityConfigurationConstants.MaxLengthOf128).IsUnicode(false);
           
        }
    }
}

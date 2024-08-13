using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionTracker.Domain.Entities;

namespace NutritionTracker.Infrastructure.Database.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(128);

            builder.Property(u => u.Hash).IsRequired();
            builder.Property(u => u.Hash).HasMaxLength(128);

            builder.Property(u => u.Salt).IsRequired();
            builder.Property(u => u.Salt).HasMaxLength(128);

            builder.Property(u => u.Roles).IsRequired();
            builder.Property(u => u.Roles).HasMaxLength(128);

            builder.Property(u => u.Enabled).IsRequired();            
        }
    }
}

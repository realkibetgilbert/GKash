using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace UserService.Infrastructure.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.Property(u => u.DateCreated)
                .IsRequired();

            builder.Property(u => u.LastLogin)
                .IsRequired(false);
        }
    }
}

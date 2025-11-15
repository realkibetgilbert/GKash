using LoanService.Domain.Entities;
using LoanService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanService.Infrastructure.ModelConfigurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.UserId)
                   .IsRequired();

            builder.Property(l => l.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(l => l.InterestRate)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)");

            builder.Property(l => l.TotalPayable)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(l => l.DurationDays)
                   .IsRequired();

            builder.Property(l => l.DateApplied)
                   .IsRequired();

            builder.Property(l => l.DueDate)
                   .IsRequired();

            builder.Property(l => l.Status)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue(LoanStatus.Pending);

            builder.HasIndex(l => l.UserId);
        }
    }
}

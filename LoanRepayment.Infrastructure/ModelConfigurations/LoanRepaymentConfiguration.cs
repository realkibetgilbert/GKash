using LoanRepayment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanRepayment.Infrastructure.ModelConfigurations
{
    public class LoanRepaymentConfiguration : IEntityTypeConfiguration<Repayment>
    {
        public void Configure(EntityTypeBuilder<Repayment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalPayable)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Balance)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.InterestAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DueDate)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.HasIndex(x => x.LoanId)
                   .IsUnique(); // one repayment per loan for MVP

            builder.HasIndex(x => x.UserId);
        }
    }
}

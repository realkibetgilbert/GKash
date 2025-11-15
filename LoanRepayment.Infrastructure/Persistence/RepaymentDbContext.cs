using LoanRepayment.Domain.Entities;
using LoanRepayment.Infrastructure.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LoanRepayment.Infrastructure.Persistence
{
    public class RepaymentDbContext : DbContext
    {
        public RepaymentDbContext(DbContextOptions<RepaymentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Repayment> LoanRepayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoanRepaymentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

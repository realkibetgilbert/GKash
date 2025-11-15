using LoanService.Domain.Entities;
using LoanService.Infrastructure.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Infrastructure.Persistence
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options)
            : base(options)
        {
        }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

using LoanService.Domain.Entities;
using LoanService.Domain.Interfaces;
using LoanService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Infrastructure.Repositories
{
    public class LoanRepository: ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> AddAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }
        public async Task<Loan?> GetByIdAsync(long id)
        {
            return await _context.Loans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}

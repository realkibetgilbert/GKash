using LoanService.Domain.Entities;

namespace LoanService.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> AddAsync(Loan loan);
        Task<Loan?> GetByIdAsync(long id);
        Task UpdateAsync(Loan loan);
    }
}

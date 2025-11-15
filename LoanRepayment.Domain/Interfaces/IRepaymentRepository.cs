using LoanRepayment.Domain.Entities;

namespace LoanRepayment.Domain.Interfaces
{
    public interface IRepaymentRepository
    {
        Task<Repayment> AddAsync(Repayment repayment);
        Task<Repayment?> GetByIdAsync(long id);
        Task<IEnumerable<Repayment>> GetByLoanIdAsync(long loanId);
        Task UpdateAsync(Repayment repayment);
    }
}

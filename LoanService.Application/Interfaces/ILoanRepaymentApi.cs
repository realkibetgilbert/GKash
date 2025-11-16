using LoanService.Application.Dtos.Repayments;

namespace LoanService.Application.Interfaces
{
    public interface ILoanRepaymentApi
    {
        Task CreateRepaymentAsync(CreateRepaymentDto dto);
    }

}

using LoanService.Domain.Entities;
using MediatR;

namespace LoanService.Application.Features.Loans.Commands
{
    public class ApplyLoanCommand : IRequest<Loan>
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
    }

}
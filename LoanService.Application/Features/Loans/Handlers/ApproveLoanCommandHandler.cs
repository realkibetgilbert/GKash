using LoanService.Application.Features.Loans.Commands;
using LoanService.Domain.Enums;
using LoanService.Domain.Interfaces;
using MediatR;


namespace LoanService.Application.Features.Loans.Handlers
{
    public class ApproveLoanCommandHandler : IRequestHandler<ApproveLoanCommand, bool>
    {
        private readonly ILoanRepository _loanRepository;

        public ApproveLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<bool> Handle(ApproveLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.LoanId);

            if (loan == null || loan.Status != LoanStatus.Pending)
                return false;

            loan.Status = LoanStatus.Active;
            loan.ApprovalDate = DateTime.UtcNow;
            loan.DueDate = DateTime.UtcNow.AddDays(loan.DurationDays);
            await _loanRepository.UpdateAsync(loan);

            return true;
        }
    }
}
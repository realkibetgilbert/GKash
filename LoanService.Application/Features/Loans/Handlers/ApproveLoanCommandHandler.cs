using LoanService.Application.Dtos.Repayments;
using LoanService.Application.Features.Loans.Commands;
using LoanService.Application.Interfaces;
using LoanService.Domain.Enums;
using LoanService.Domain.Interfaces;
using MediatR;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


namespace LoanService.Application.Features.Loans.Handlers
{
    public class ApproveLoanCommandHandler : IRequestHandler<ApproveLoanCommand, bool>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanRepaymentApi _repaymentApi;

        public ApproveLoanCommandHandler(ILoanRepository loanRepository, ILoanRepaymentApi repaymentApi)
        {
            _loanRepository = loanRepository;
            _repaymentApi = repaymentApi;
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

            var interestAMount = loan.TotalPayable - loan.Amount;
            var repaymentDto = new CreateRepaymentDto(
               loan.Id,
               loan.UserId,
               loan.TotalPayable,
               interestAMount,
               loan.DueDate
           );
            await _repaymentApi.CreateRepaymentAsync(repaymentDto);
            return true;
        }
    }
}
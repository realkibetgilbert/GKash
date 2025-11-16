using LoanService.Application.Features.Loans.Commands;
using LoanService.Domain.Entities;
using LoanService.Domain.Enums;
using LoanService.Domain.Interfaces;
using MediatR;

namespace LoanService.Application.Features.Loans.Handlers
{
    public class ApplyLoanCommandHandler : IRequestHandler<ApplyLoanCommand, Loan>
    {
        private readonly ILoanRepository _loanRepository;
        private const decimal InterestRate = 0.45M;

        public ApplyLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Loan> Handle(ApplyLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan
            {
                UserId = request.UserId,
                Amount = request.Amount,
                InterestRate = InterestRate,
                TotalPayable = request.Amount + (request.Amount * InterestRate),
                DateApplied = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(30),
                DurationDays = 30,
                Status = LoanStatus.Pending
            };

            return await _loanRepository.AddAsync(loan);
        }
    }
}

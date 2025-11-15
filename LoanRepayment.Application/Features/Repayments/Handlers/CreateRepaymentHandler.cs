using LoanRepayment.Application.Features.Repayments.Commands;
using LoanRepayment.Domain.Entities;
using LoanRepayment.Domain.Enums;
using LoanRepayment.Domain.Interfaces;
using MediatR;

namespace LoanRepayment.Application.Features.Repayments.Handlers
{
    public class CreateRepaymentHandler : IRequestHandler<CreateRepaymentCommand, long>
    {
        private readonly IRepaymentRepository _repository;

        public CreateRepaymentHandler(IRepaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(CreateRepaymentCommand request, CancellationToken cancellationToken)
        {
            var repayment = new Repayment
            {
                LoanId = request.LoanId,
                UserId = request.UserId,
                TotalPayable = request.TotalPayable,
                Balance = request.TotalPayable,
                InterestAmount = request.InterestAmount,
                DueDate = request.DueDate,
                Status = RepaymentStatus.Pending
            };

            var createdRepayment = await _repository.AddAsync(repayment);
            return createdRepayment.Id;
        }
    }
}

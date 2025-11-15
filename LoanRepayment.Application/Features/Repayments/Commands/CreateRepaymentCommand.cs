using MediatR;

namespace LoanRepayment.Application.Features.Repayments.Commands
{
    public record CreateRepaymentCommand(
        long LoanId,
        long UserId,
        decimal TotalPayable,
        decimal InterestAmount,
        DateTime DueDate
    ) : IRequest<long>;
}

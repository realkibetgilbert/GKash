namespace LoanService.Application.Dtos.Repayments
{
    public record CreateRepaymentDto(
    long LoanId,
    long UserId,
    decimal TotalPayable,
    decimal InterestAmount,
    DateTime? DueDate
);
}

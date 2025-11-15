using LoanRepayment.Domain.Enums;

namespace LoanRepayment.Domain.Entities
{
    public class Repayment
    {
        public long Id { get; set; }
        public long LoanId { get; set; }
        public long UserId { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public RepaymentStatus Status { get; set; } = RepaymentStatus.Pending;
    }
}

using LoanService.Domain.Enums;

namespace LoanService.Domain.Entities
{
    public class Loan
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalPayable { get; set; }
        public int DurationDays { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Pending;
    }

}

namespace LibraryOnline.Core.Entities
{
    public class Fine :BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid LoanId { get; set; }
        public Loan Loan { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Reason { get; set; }  = string.Empty;
        public DateTime? PaidAt { get; set; }
    }
}
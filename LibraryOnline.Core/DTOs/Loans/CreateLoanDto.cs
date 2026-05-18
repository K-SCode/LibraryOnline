namespace LibraryOnline.Core.DTOs.Loans
{
    public class CreateLoanDto
    {
        public Guid UserID { get; set; }
        public Guid BookId { get; set; }
        public int LoanDays { get; set; } = 30;
    }
}

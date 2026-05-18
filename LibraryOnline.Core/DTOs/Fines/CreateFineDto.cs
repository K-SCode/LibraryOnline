namespace LibraryOnline.Core.DTOs.Fines
{
    public class CreateFineDto
    {
        public Guid UserId {  get; set; }
        public Guid LoanId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}

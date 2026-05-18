namespace LibraryOnline.Core.DTOs.Loans
{
    public class LoanReasonDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string BookTitle {  get; set; } = string.Empty;
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDay { get; set; }
        public bool IsReturn => ReturnDay.HasValue;
        public string Status { get; set; } = string.Empty;
    }
}

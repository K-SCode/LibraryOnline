namespace LibraryOnline.Core.DTOs.Fines
{
    public class FineResponseDto
    {
        public Guid Id {  get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string BookTitle {  get; set; } = string.Empty;
        public string Reason {  get; set; } = string.Empty;
        public DateTime? PaidAt { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsPaid => PaidAt.HasValue;
        public decimal Amount { get; set; }
    }
}

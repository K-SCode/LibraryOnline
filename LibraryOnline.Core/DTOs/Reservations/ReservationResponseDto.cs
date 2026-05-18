namespace LibraryOnline.Core.DTOs.Reservations
{
    public class ReservationResponseDto
    {
        public Guid Id { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public bool IsCanceled => CanceledAt.HasValue;
        public string Status { get; set; } = string.Empty;
    }
}

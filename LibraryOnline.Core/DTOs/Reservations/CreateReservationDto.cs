namespace LibraryOnline.Core.DTOs.Reservations
{
    public class CreateReservationDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ReservedAt { get; set; }
        public int ReservationDays { get; set; } = 7;
        public string Status { get; set; } = string.Empty;
    }
}

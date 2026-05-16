using LibraryOnline.Core.Enums;

namespace LibraryOnline.Core.Entities
{
    public class Reservation :BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public DateTime ReservedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;
    }
}
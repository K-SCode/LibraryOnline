using LibraryOnline.Core.Enums;

namespace LibraryOnline.Core.Entities
{
    public class Loan :BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public ICollection<Fine> Fines { get; set; } = [];
        public DateOnly LoanDate { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Active;

    }
}
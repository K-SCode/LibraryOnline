namespace LibraryOnline.Core.Entities
{
    public class User :BaseEntity
    {
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Guid RoleId {  get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<Fine> Fines { get; set; } = [];
        public ICollection<Note> Notes { get; set; } = [];
        public ICollection<Review> Reviews { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
        public ICollection<Loan> Loans { get; set; } = [];
    }
}
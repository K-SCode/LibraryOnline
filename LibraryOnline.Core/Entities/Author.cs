namespace LibraryOnline.Core.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public ICollection<Book> Books { get; set; } = [];
    }
}
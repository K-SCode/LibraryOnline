namespace LibraryOnline.Core.DTOs.Books
{
    public class UpdateBookDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string? CoverImageURL { get; set; }
        public int TotalCopies { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
    }
}

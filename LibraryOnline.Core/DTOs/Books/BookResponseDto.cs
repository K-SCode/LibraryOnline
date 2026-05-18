namespace LibraryOnline.Core.DTOs.Books
{
    public class BookResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? CoverImageURL { get; set; }
        public int TotalCopies { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorFullName { get; set; } = string.Empty;
        public string CategoryName {  get; set; } = string.Empty;
    }
}

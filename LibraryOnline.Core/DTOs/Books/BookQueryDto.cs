namespace LibraryOnline.Core.DTOs.Books
{
    public class BookQueryDto
    {
        public string? Search {  get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AuthorOd {  get; set; }
        public string? Sort {  get; set; } 
        public string? Page {  get; set; }
        public string? PageSizE { get; set; }
    }
}

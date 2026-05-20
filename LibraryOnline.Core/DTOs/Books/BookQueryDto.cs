namespace LibraryOnline.Core.DTOs.Books
{
    public class BookQueryDto
    {
        public string? Search {  get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AuthorId {  get; set; }
        public string? Sort {  get; set; } 
        public int Page {  get; set; }
        public int PageSize { get; set; }
    }
}

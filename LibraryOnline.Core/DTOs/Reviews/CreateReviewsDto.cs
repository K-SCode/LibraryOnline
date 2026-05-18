namespace LibraryOnline.Core.DTOs.Reviews
{
    public class CreateReviewsDto
    {
        public Guid BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}

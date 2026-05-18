namespace LibraryOnline.Core.DTOs.Reviews
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}

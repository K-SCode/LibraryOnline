namespace LibraryOnline.Core.DTOs.Notes
{
    public class CreateNoteDto
    {
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string Priority { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}

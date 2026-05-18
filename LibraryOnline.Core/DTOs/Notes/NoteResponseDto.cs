
namespace LibraryOnline.Core.DTOs.Notes
{
    public class NoteResponseDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public string AuthorFullName { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string Priority { get; set; } = string.Empty;
    }
}
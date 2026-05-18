public class UpdateNoteDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}

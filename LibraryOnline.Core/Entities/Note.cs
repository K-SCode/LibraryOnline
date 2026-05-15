using LibraryOnline.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.Entities
{
    public class Note : BaseEntity
    {

        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public NotePriority Priority { get; set; } = NotePriority.Low;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}

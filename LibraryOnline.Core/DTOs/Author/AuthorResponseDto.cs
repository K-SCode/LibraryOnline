using LibraryOnline.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.DTOs.Author
{
    public class AuthorResponseDto
    {
        public Guid Id { get; set;  }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Bio { get; set; }
    }
}

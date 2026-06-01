using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.DTOs.Author
{
    public class CreateAuthorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Bio { get; set; }
    }
}

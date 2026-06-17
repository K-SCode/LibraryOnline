using LibraryOnline.Core.Constants;
using LibraryOnline.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.DTOs.Users
{
    public class UserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid RoleId { get; set; } = SeedData.Roles.UserId;

    }
}

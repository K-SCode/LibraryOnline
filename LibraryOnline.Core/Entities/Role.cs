using LibraryOnline.Core.Enums;

namespace LibraryOnline.Core.Entities
{
    public class Role :BaseEntity
    {
        public RoleNamecs Name { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
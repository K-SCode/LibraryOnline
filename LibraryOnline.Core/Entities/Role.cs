using LibraryOnline.Core.Enums;

namespace LibraryOnline.Core.Entities
{
    public class Role :BaseEntity
    {
        public RoleName Name { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
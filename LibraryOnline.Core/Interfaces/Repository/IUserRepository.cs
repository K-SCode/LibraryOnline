using LibraryOnline.Core.Entities;

namespace LibraryOnline.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}

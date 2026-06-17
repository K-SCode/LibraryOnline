using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryOnline.Infrastructure.Repositories
{
    internal class UserRepository(ApplicationDbContext dbContext) :
        Repository<User>(dbContext), IUserRepository
    {
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(
                user => user.Email == email);
        }
    }
}
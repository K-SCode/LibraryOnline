
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.DTOs.Users;

namespace LibraryOnline.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task UpdateUserPasswordAsync(Guid id, ChangePasswordDto password);
        Task UpdateUserEmailAsync(UpdateUserDto userDto);
        Task UpdateUserPhoneAsync(UpdateUserDto userDto);
        Task UpdateUserOwnerNameAsync(UpdateUserDto userDto);
        Task UpdateRoleAsync(Guid userId, Guid roleId);
        Task DeleteUserAsync(Guid id);
        Task CreateUserAsync(UserDto userDto);
        Task<UserResponseDto?> GetUserByIdAsync(Guid id);
        Task<UserResponseDto?> GetUserByEmailAsync(string email);
        Task<PagedResultDto<UserResponseDto>?> GetAllUsersAsync(int pageNumber, int pageSize);
    }
}

using LibraryOnline.Core.DTOs.Categories;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.DTOs.Users;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using LibraryOnline.Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using static LibraryOnline.Core.Constants.SeedData;

namespace LibraryOnline.API.Services
{
    public class UserService(IUnitOfWorks unitOfWorks,
        IMapper mapper) : IUserService
    {
        public async Task CreateUserAsync(UserDto userDto)
        {
            Dictionary<string, string> propertyToCheck = new()
            {
                {nameof(User.Email),userDto.Email },
                {nameof(User.Phone),userDto.Phone  },
            };
            var isExists = await unitOfWorks.Users.ExistsAsync(propertyToCheck);
            if (isExists)
            {
                throw new ArgumentException($"User with phone {userDto.Phone} or email: {userDto.Email} already exists");
            }

            var user = mapper.Map<User>(userDto);

            await unitOfWorks.Users.AddAsync(user);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await unitOfWorks.Users.GetByIdAsync(id);
            
            if(user is null)
            {
                throw new ArgumentNullException($"User with id: {id} is not exists");
            }

            unitOfWorks.Users.Delete(user);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task<PagedResultDto<UserResponseDto>?> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            (IEnumerable<User> items, int totalCount) = await unitOfWorks.Users.GetAllAsync(pageNumber, pageSize);

            return new PagedResultDto<UserResponseDto>
            {
                Items = items.Adapt<IEnumerable<UserResponseDto>>(),
                TotalCount = totalCount,
                Page = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<UserResponseDto?> GetUserByEmailAsync(string email)
        {
            var user = await unitOfWorks.Users.GetUserByEmailAsync(email);
            if (user is null)
            {
                return null;
            }
            var respone = mapper.Map<UserResponseDto>(user);
            return respone;
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(Guid id)
        {
            var user = await unitOfWorks.Users.GetByIdAsync(id);
            if (user is null)
            {
                return null;
            }
            var respone = mapper.Map<UserResponseDto>(user);
            return respone;
        }

        public async Task UpdateRoleAsync(Guid userId, Guid roleId)
        {
            Dictionary<string, string> propertyRoleToCheck = new()
            {
                {nameof(Role.Id),roleId.ToString()}
            };
            var roleExists = await unitOfWorks.Roles.ExistsAsync(propertyRoleToCheck);
            if (!roleExists)
            {
                throw new ArgumentException($"Role with id: {roleId} not exists");
            }

            var user = await unitOfWorks.Users.GetByIdAsync(userId) ??
                throw new ArgumentNullException($"user with Id: {userId} not exists");

            user.RoleId = roleId;

            unitOfWorks.Users.Update(user);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task UpdateUserEmailAsync(UpdateUserDto userDto)
        {
            var user = await unitOfWorks.Users.GetUserByEmailAsync(userDto.Email) ??
                throw new ArgumentNullException($"user with Email: {userDto.Email} not exists");

            user.Email = userDto.Email;

            unitOfWorks.Users.Update(user);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task UpdateUserOwnerNameAsync(UpdateUserDto userDto)
        {
            var user = await unitOfWorks.Users.GetByIdAsync(userDto.Id) ??
                throw new ArgumentNullException($"User with Id: {userDto.Id}not exists");

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;

            unitOfWorks.Users.Update(user);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task UpdateUserPasswordAsync(Guid id, ChangePasswordDto password)
        {
            var user = await unitOfWorks.Users.GetByIdAsync(id) ??
                throw new ArgumentNullException($"User with Id: {id} not exists");

            var passwordVerication = new PasswordHasher<User>();

            var checkPassword = passwordVerication.VerifyHashedPassword(
                user, user.PasswordHash, password.OldPassword);

            if(checkPassword == PasswordVerificationResult.Success)
            {
                if(password.NewPassword == password.ConfirmPassword)
                {
                    user.PasswordHash = passwordVerication.HashPassword(user, password.ConfirmPassword);

                    unitOfWorks.Users.Update(user);
                    await unitOfWorks.SaveChangesAsync();
                }
            } 
        }

        public async Task UpdateUserPhoneAsync(UpdateUserDto userDto)
        {
            var user = await unitOfWorks.Users.GetByIdAsync(userDto.Id) ??
                throw new ArgumentNullException($"User with Id: {userDto.Id} not exists");

            Dictionary<string, string> propertyToCheck = new()
            {
                {nameof(User.Phone), userDto.Phone }
            };

            var isExists = await unitOfWorks.Users.ExistsAsync(propertyToCheck);
            if(isExists)
            {
                throw new ArgumentException($"Phone : {userDto.Phone} already exists");
            }

            user.Phone = userDto.Phone;

            unitOfWorks.Users.Update(user);
            await unitOfWorks.SaveChangesAsync();
        }
    }
}

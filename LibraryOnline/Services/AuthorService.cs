using LibraryOnline.Core.DTOs.Author;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using MapsterMapper;

namespace LibraryOnline.API.Services
{
    public class AuthorService(
        IUnitOfWorks unitOfWorks,
        IMapper mapper) : IAuthorService
    {
        public async Task CreateAuthorAsync(CreateAuthorDto createAuthor)
        {
            ArgumentNullException.ThrowIfNull(createAuthor);

            var author = mapper.Map<Author>(createAuthor);
            
            await unitOfWorks.Authors.AddAsync(author);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            var authorToDelete = await unitOfWorks.Authors.GetByIdAsync(id);

            ArgumentNullException.ThrowIfNull(authorToDelete);

            unitOfWorks.Authors.Delete(authorToDelete);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task<PagedResultDto<AuthorResponseDto>?> GetAllAuthorsAsync(int pageNumber, int pageSize)
        {
            var items = await unitOfWorks.Authors.GetAllAsync(pageNumber, pageSize);



        }

        public Task<AuthorResponseDto?> GetAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthor)
        {
            throw new NotImplementedException();
        }
    }
}

using LibraryOnline.Core.DTOs.Author;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using Mapster;
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

            Dictionary<string, string> checkElements = new()
            {
                { nameof(Author.FirstName), createAuthor.FirstName },
                { nameof(Author.LastName), createAuthor.LastName  }
            };

            var isExists = await unitOfWorks.Authors.ExistsAsync(checkElements);

            if (!isExists)
            {
                var author = mapper.Map<Author>(createAuthor);
            
                await unitOfWorks.Authors.AddAsync(author);
                await unitOfWorks.SaveChangesAsync();
            }

        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            var authorToDelete = await unitOfWorks.Authors.GetByIdAsync(id) ??
                throw new ArgumentNullException($"Author with {id} not exists");

            unitOfWorks.Authors.Delete(authorToDelete);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task<PagedResultDto<AuthorResponseDto>?> GetAllAuthorsAsync(int pageNumber, int pageSize)
        {
            (IEnumerable<Author >items, int totalCount) = await unitOfWorks.Authors.GetAllAsync(pageNumber, pageSize);

            return new PagedResultDto<AuthorResponseDto>
            {
                Items = items.Adapt<IEnumerable<AuthorResponseDto>>(),
                TotalCount = totalCount,
                Page = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<AuthorResponseDto?> GetAuthorByIdAsync(Guid id)
        {
            var author = await unitOfWorks.Authors.GetByIdAsync(id);
            if(author is null)
            {
                return null;
            }

            var result = mapper.Map<AuthorResponseDto>(author);
            
            return result;
        }

        public async Task UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthor)
        {
            var author = await unitOfWorks.Authors.GetByIdAsync(id);

            ArgumentNullException.ThrowIfNull(author);

            mapper.Map(updateAuthor,author);

            unitOfWorks.Authors.Update(author); 
            await unitOfWorks.SaveChangesAsync();
        }
    }
}

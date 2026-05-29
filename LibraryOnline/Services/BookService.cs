using LibraryOnline.Core.Common;
using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using Mapster;
using MapsterMapper;

namespace LibraryOnline.API.Services
{
    public class BookService(
        IUnitOfWorks unitOfWorks,
        IMapper mapper) : IBookService
    {
        public async Task CreateBookAsync(CreateBookDto createBook)
        {
            ArgumentNullException.ThrowIfNull(createBook);

            var book = mapper.Map<Book>(createBook);

            await unitOfWorks.Books.AddAsync(book);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await unitOfWorks.Books.GetByIdAsync(id);

            ArgumentNullException.ThrowIfNull(book);

            unitOfWorks.Books.Delete(book);
            await unitOfWorks.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Guid id, UpdateBookDto updateBook)
        {
            var book = await unitOfWorks.Books.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(book);
            
            ArgumentNullException.ThrowIfNull(updateBook);

            mapper.Map(updateBook, book);
            
            unitOfWorks.Books.Update(book);
            await unitOfWorks.SaveChangesAsync();

        }
        public async Task<PagedResultDto<BookResponseDto>?> GetAllBookAsync(BookQueryDto queryDto)
        {
            ArgumentNullException.ThrowIfNull(queryDto);

            var query = mapper.Map<BookQuery>(queryDto);
            var (books, totalCount) = await unitOfWorks.Books.GetAllAsync(query);

            return new PagedResultDto<BookResponseDto>()
            {
                Items = books.Adapt<IEnumerable<BookResponseDto>>(),
                TotalCount = totalCount,
                Page = queryDto.Page,
                PageSize = queryDto.PageSize
            };
        }
        public async Task<BookResponseDto?> GetBookByIdAsync(Guid id)
        {
            var book = await unitOfWorks.Books.GetByIdAsync(id);

            if (book is null)
            {
                return null;
            }
            var response = mapper.Map<BookResponseDto>(book);
            return response;
        }

    }
}

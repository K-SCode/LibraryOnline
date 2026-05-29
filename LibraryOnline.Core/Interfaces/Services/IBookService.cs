using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.DTOs.Common;

namespace LibraryOnline.Core.Interfaces.Services
{
    public interface IBookService
    {
        public Task DeleteBookAsync(Guid id);
        public Task UpdateBookAsync(Guid id ,UpdateBookDto updateBook);
        public Task CreateBookAsync(CreateBookDto createBook);
        public Task<BookResponseDto?> GetBookByIdAsync(Guid id);
        public Task<PagedResultDto<BookResponseDto>?> GetAllBookAsync(BookQueryDto queryDto);
    }
}

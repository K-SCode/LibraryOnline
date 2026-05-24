using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.DTOs.Common;

namespace LibraryOnline.Core.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BookResponseDto?> GetBookById(Guid id);

        public Task<PagedResultDto<IEnumerable<BookResponseDto>>?> GetAllBook(BookQueryDto queryDto);
        public Task<BookResponseDto> GetBookByTitle(string title);

        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByAuthorId(Guid authorId);
        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByCategoryId(Guid categoryId);
        public void DeleteBook(Guid id);
        public void UpdateBook(UpdateBookDto updateBook);
        public Task CreateBook(CreateBookDto createBook);
    }
}

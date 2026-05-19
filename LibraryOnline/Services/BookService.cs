using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.DTOs.Common;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Core.Interfaces.Services;
using MapsterMapper;

namespace LibraryOnline.API.Services
{
    public class BookService(
        IUnitOfWorks unitOfWorks,
        IMapper mapper) : IBookService
    {
        public async Task<BookResponseDto?> GetBookById(Guid id)
        {

            var book = await unitOfWorks.Books.GetByIdAsync(id);

            if(book is null)
            {
                return null;
            }

            var response = MapToResponse(book);
            return response;
        }
        private BookResponseDto MapToResponse(Book book ) =>
            mapper.Map<BookResponseDto>(book);
        public async Task<PagedResultDto<BookResponseDto>> GetAllBook()
        {
            var books = await unitOfWorks.Books.GetAllAsync();
            if (books is null)
            {
                return null;
            }

            var response = new List<BookResponseDto>();
            foreach(var book in books)
            {
                var tmp = MapToResponse(book);
                response.Add(tmp);
            }
            return response;
        }
        public Task<BookResponseDto> GetBookByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByAuthorId(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByCategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }
        public void DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateBook(UpdateBookDto updateBook)
        {
            throw new NotImplementedException();
        }


        public Task CreateBook(CreateBookDto createBook)
        {
            throw new NotImplementedException();
        }
    }
}

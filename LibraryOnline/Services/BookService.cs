using LibraryOnline.Core.Common;
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
        public async Task CreateBook(CreateBookDto createBook)
        {
            if(createBook is null)
            {
                throw new ArgumentNullException(nameof(createBook));
            }
            var book = mapper.Map<Book>(createBook);

            await unitOfWorks.Books.AddAsync(book);
            await unitOfWorks.SaveChangesAsync();

        }

        public void DeleteBook(Guid id)
        {
            unitOfWorks.Books.Delete(id);
            unitOfWorks.SaveChanges();
        }

        public async Task<PagedResultDto<IEnumerable<BookResponseDto>>?> GetAllBook(BookQueryDto queryDto)
        {
            if(queryDto is null)
            {
                throw new ArgumentNullException(nameof(queryDto));
            }
            var query = mapper.Map<BookQuery>(queryDto);

            var allBooks = await unitOfWorks.Books.GetAllAsync(query);

            var responseBooks = new List<BookResponseDto>();
            foreach(var book in allBooks)
            {
                var tmp = mapper.Map<BookResponseDto>(book);
                responseBooks.Add(tmp);
            }

            

            return allBooks;
        }

        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByAuthorId(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BookResponseDto>> GetAllBooksByCategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }

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

        public Task<BookResponseDto> GetBookByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(UpdateBookDto updateBook)
        {
            throw new NotImplementedException();
        }

        private BookResponseDto MapToResponse(Book book ) =>
            mapper.Map<BookResponseDto>(book);
       
    }
}

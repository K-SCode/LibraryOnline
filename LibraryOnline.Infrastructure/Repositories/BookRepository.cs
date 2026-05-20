using LibraryOnline.Core.DTOs.Books;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryOnline.Infrastructure.Repositories
{
    internal class BookRepository(
        ApplicationDbContext dbContext) : IBookRepository
    {
        private readonly DbSet<Book> _dbSet = dbContext.Set<Book>();

        public async Task AddAsync(Book entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(Book entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.FindAsync(id) is not null;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<IEnumerable<Book>> GetAllAsync(BookQueryDto query)
        {
            var bookQuery = _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsQueryable();

            if(query.CategoryId is not null)
            {
                bookQuery.Where(b => b.CategoryId == query.CategoryId);
            }
            if(query.AuthorId is not null){
                bookQuery.Where(b => b.AuthorId == query.AuthorId);
            }
            if (string.IsNullOrEmpty(query.Search))
            {
                bookQuery = bookQuery.Where(
                    b => b.ISBN.Contains(query.Search) ||
                         b.Title.Contains(query.Search));
            }

            bookQuery = query.Sort switch
            {
                "title" => bookQuery.OrderBy(b => b.Title),
                "category" => bookQuery.OrderBy(b => b.Category.Name),
                "publishedDate" => bookQuery.OrderBy(b => b.PublishedDate),
                _ => bookQuery.OrderBy(b => b.Id)
            };

            var totalCount = bookQuery.Count();

            
        }

        public Task<Book?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
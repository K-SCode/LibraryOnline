using LibraryOnline.Core.Common;
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
            return await _dbSet.AnyAsync(tmp => tmp.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<(IEnumerable<Book>, int totalCount)> GetAllAsync(BookQuery query)
        {
            var bookQuery = _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsQueryable();

            if(query.CategoryId is not null)
            {
                bookQuery = bookQuery.Where(b => b.CategoryId == query.CategoryId);
            }
            if(query.AuthorId is not null){
                bookQuery = bookQuery.Where(b => b.AuthorId == query.AuthorId);
            }
            if (!string.IsNullOrEmpty(query.Search))
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
                _ => bookQuery.OrderBy(b => b.CreatedAt)    
            };

            var totalCount = await bookQuery.CountAsync();

            var books = await bookQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return (books, totalCount);
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            var book = await _dbSet.FindAsync(id);
            return book;
        }

        public void Update(Book entity)
        {
            _dbSet.Update(entity);
        }
    }
}
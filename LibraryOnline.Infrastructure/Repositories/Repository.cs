using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryOnline.Infrastructure.Repositories
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet ;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public void Delete(T entity) =>
            _dbSet.Remove(entity);

        public async Task<bool> ExistsAsync(Guid id) =>
            await _dbSet.AnyAsync(tmp => tmp.Id == id);
        public async Task<(IEnumerable<T>,int)> GetAllAsync(int pageNumber, int pageSize)
        {
            var bookQuery = _dbSet.AsQueryable();

            var totalCount = await bookQuery.CountAsync();
            
            var books = await bookQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (books, totalCount);
        }

        public async Task<T?> GetByIdAsync(Guid id) =>
            await _dbSet.FindAsync(id);

        public void Update(T entity) =>
            _dbSet.Update(entity);
    
    }
}

using LibraryOnline.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task<(IEnumerable<T>, int)> GetAllAsync(int pageNumber, int PageSize);
        Task<T?> GetByIdAsync(Guid id);
        void Delete(T entity);
        Task<bool> ExistsAsync(Guid id);
        void Update(T entity);
    }
}

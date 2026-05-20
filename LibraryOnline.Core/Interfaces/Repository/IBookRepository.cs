using LibraryOnline.Core.Common;
using LibraryOnline.Core.Entities;

namespace LibraryOnline.Core.Interfaces.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAsync(BookQuery query);
        
    }
}

using LibraryOnline.Core.Common;
using LibraryOnline.Core.Entities;

namespace LibraryOnline.Core.Interfaces.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<(IEnumerable<Book>,int totalCount)> GetAllAsync(BookQuery query);
    }
}

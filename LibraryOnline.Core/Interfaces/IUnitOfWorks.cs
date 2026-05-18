using LibraryOnline.Core.Entities;

namespace LibraryOnline.Core.Interfaces
{
    public interface IUnitOfWorks
    {
        IBookRepository Books { get;}
        IUserRepository Users { get;}
        INoteRepository Notes { get;}
        IReservationRepository Reservations { get;}
        IReviewRepository Reviews { get;}

        IRepository<Author> Authors{ get; }
        IRepository<Category> Categories{ get; }
        IRepository<Role> Roles { get; }
        IRepository<Fine> Fines { get; }
        Task<int> SaveChangesAsync();
    }
}

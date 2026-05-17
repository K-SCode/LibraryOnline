using LibraryOnline.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Core.Interfaces
{
    public interface IUnitOfWorks : IDisposable
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

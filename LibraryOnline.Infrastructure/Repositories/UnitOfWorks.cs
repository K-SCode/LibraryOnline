using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces;
using LibraryOnline.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOnline.Infrastructure.Repositories
{
    public class UnitOfWorks(
        ApplicationDbContext context) 
    {
        private IRepository<Author> _authors;
        private IRepository<Category> _categories;
        private IRepository<Role> _roles;
        private IRepository<Fine> _fines;

        public IRepository<Author> Auhors => _authors ??= new Repository<Author>(context);
        public IRepository<Category>
        public IRepository<Role>
        public IRepository<Fine> 


        public IBookRepository Book => _author ??= new BookRepository();
        public IUserRepository User => new UserRepository();
        public INoteRepository Note => new NoteRepository();
        public IReservationRepository Reservation => new ReservationRepository();
        public IReviewRepository review => new ReviewRepository();
        public void Dispose()
        {
            context.Dispose();
        }
        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
        public async Task<int> SaveChangesAsync() =>
            await context.SaveChangesAsync();
    }
}

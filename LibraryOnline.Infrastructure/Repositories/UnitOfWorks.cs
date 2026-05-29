using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Interfaces.Repository;
using LibraryOnline.Infrastructure.Data;

namespace LibraryOnline.Infrastructure.Repositories
{
    public class UnitOfWorks(
        ApplicationDbContext context)  : IUnitOfWorks
    {
        private IRepository<Author>? _authors;
        private IRepository<Category>? _categories;
        private IRepository<Role>? _roles;
        private IRepository<Fine>? _fines;

        private IBookRepository? _books;
        private IUserRepository? _users;
        private INoteRepository? _notes;
        private IReservationRepository? _reservations;
        private IReviewRepository? _reviews;

        public IRepository<Author> Authors =>
            _authors ??= new Repository<Author>(context);
        public IRepository<Category> Categories =>
            _categories ??= new Repository<Category>(context);
        public IRepository<Role> Roles => 
            _roles ??= new Repository<Role>(context);
        public IRepository<Fine> Fines =>
            _fines ??= new Repository<Fine>(context);

        public IBookRepository Books => _books ??= new BookRepository(context);
        public IUserRepository Users => _users ??= new UserRepository();
        public INoteRepository Notes => _notes ??= new NoteRepository();
        public IReservationRepository Reservations =>
            _reservations ??= new ReservationRepository();
        public IReviewRepository Reviews =>
            _reviews ??= new ReviewRepository();

        public async Task<int> SaveChangesAsync() =>
            await context.SaveChangesAsync();
    }
}

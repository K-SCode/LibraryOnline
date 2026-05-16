using LibraryOnline.Core.Constants;
using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace LibraryOnline.Infrastructure.Data
{
    public class ApplicationDbContext(
        DbContextOptions options,
        IConfiguration configuration) : DbContext(options)
    {
        private readonly IConfiguration _configuration = configuration;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);


        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSeeding((context, _) =>
            {
                if (!context.Set<User>().Any(x => x.Id == SeedData.Users.AdminId))
                {
                    context.Set<User>().Add(
                        new User
                        {
                            Id = SeedData.Users.AdminId,
                            FirstName = "Admin",
                            LastName = "Admin",
                            Email = _configuration["SeedSettings:AdminEmail"]!,
                            RoleId = SeedData.Roles.AdminId,
                            Phone = "123123123",
                            PasswordHash = _configuration["SeedSettings:AdminPassword"]!,
                            CreatedAt = DateTime.UtcNow
                        });
                    context.SaveChanges();
                }
            }).UseAsyncSeeding(async(context,_,cancellationToken) =>
            {
                if (!await context.Set<User>().AnyAsync(x => x.Id == SeedData.Users.AdminId,cancellationToken))
                {
                    context.Set<User>().Add(
                        new User
                        {
                            Id = SeedData.Users.AdminId,
                            FirstName = "Admin",
                            LastName = "Admin",
                            Email = _configuration["SeedSettings:AdminEmail"]!,
                            RoleId = SeedData.Roles.AdminId,
                            Phone = "123123123",
                            PasswordHash = _configuration["SeedSettings:AdminPassword"]!,
                            CreatedAt = DateTime.UtcNow
                        });
                    await context.SaveChangesAsync(cancellationToken);
                }
            });
        }
    }
}

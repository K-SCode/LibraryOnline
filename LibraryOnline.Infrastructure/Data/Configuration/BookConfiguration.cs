using LibraryOnline.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.ISBN)
                .HasMaxLength(13)
                .IsRequired();

            builder.HasIndex(e => e.ISBN)
                .IsUnique();

            builder.Property(e => e.TotalCopies)
                .IsRequired();

            builder.Property(e => e.PublishedDate)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.HasOne(e => e.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}

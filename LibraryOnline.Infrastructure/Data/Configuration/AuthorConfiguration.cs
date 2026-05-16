using LibraryOnline.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.FirstName)
               .IsRequired();

            builder.Property(c => c.LastName)
                .IsRequired();

            builder.Property(c => c.Bio)
                .HasMaxLength(500);

            builder.HasMany(c => c.Books)
                .WithOne(o => o.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using LibraryOnline.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.Phone)
                .IsUnique();

            builder.Property(e => e.PasswordHash)
                .IsRequired();

            builder.HasOne(e => e.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

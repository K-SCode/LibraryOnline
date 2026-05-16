using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Content)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.ExpiresAt)
                .IsRequired();

            builder.Property(e => e.IsCompleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.Priority)
                .HasConversion<string>()
                .HasDefaultValue(NotePriority.Low)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

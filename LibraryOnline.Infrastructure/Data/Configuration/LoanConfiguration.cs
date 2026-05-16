using LibraryOnline.Core.Entities;
using LibraryOnline.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany(x => x.Loans)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Book)
                .WithMany(x => x.Loans)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.LoanDate)
                .IsRequired();

            builder.Property(e => e.DueDate)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasDefaultValue(LoanStatus.Active)
                .IsRequired();
        }
    }
}

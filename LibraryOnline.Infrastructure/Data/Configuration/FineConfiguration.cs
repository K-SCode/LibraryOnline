using LibraryOnline.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany(x => x.Fines)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Loan)
                .WithMany(x => x.Fines)
                .HasForeignKey(e => e.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Amount)
                .HasPrecision(15,2)
                .IsRequired();

            builder.Property(e => e.Reason)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

using LibraryOnline.Core.Constants;
using LibraryOnline.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOnline.Infrastructure.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
            new()
            {
                Id = SeedData.Roles.AdminId,
                Name = Core.Enums.RoleName.Admin,
            },
            new()
            {
                Id = SeedData.Roles.UserId,
                Name = Core.Enums.RoleName.User,
            },
            new()
            {
                Id = SeedData.Roles.EmployeeId,
                Name = Core.Enums.RoleName.Employee,
            });
        }
    }
}

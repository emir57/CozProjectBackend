using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
{
    public sealed class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles")
                .HasKey(u => u.Id);

            builder.HasOne(u => u.User);
            builder.HasOne(u => u.Role);

            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(u => u.RoleId)
                .IsRequired()
                .HasColumnName("RoleId");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(c => c.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

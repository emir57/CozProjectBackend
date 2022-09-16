using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
{
    public sealed class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles")
                .HasKey(r => r.Id);

            builder.HasMany(r => r.UserRoles);

            builder.Property(r => r.Id)
                .HasColumnName("Id");

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(c => c.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

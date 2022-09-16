using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            UserRole[] userRoleEntitySeeds =
            {
                new UserRole(1,1,1,DateTime.Now),
                new UserRole(2,1,2,DateTime.Now),
                new UserRole(3,1,3,DateTime.Now),
                new UserRole(4,1,4,DateTime.Now),
            };
            builder.HasData(userRoleEntitySeeds);
        }
    }
}

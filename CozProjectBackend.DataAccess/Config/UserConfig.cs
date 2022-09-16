using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
{
    public sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);

            //builder.HasMany(u => u.Roles);

            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FirstName");

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LastName");

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LastName");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Email");

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("PasswordHash");
            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("PasswordSalt");

            builder.Property(u => u.EmailConfirmed)
                .HasDefaultValue(false)
                .HasColumnName("EmailConfirmed");

            builder.Property(u => u.Score)
                .HasDefaultValue(0)
                .HasColumnName("Score");

            builder.Property(u => u.ProfilePhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("ProfilePhotoUrl");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(c => c.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

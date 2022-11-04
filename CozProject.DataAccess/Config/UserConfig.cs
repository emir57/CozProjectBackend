using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;

namespace CozProject.DataAccess.Config
{
    public sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);

            builder.HasMany(u => u.UserRoles);

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

            User adminUser = getAdminUser();
            builder.HasData(adminUser);
        }

        private User getAdminUser()
        {
            byte[] passwordHash, passwordSalt;
            string password = configuration().GetSection("AdminUser:Password").Value;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            return new User
            {
                Id = 1,
                FirstName = configuration().GetSection("AdminUser:FirstName").Value,
                LastName = configuration().GetSection("AdminUser:LastName").Value,
                Email = configuration().GetSection("AdminUser:Email").Value,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
                EmailConfirmed = true
            };
        }

        private static IConfigurationRoot configuration()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return configurationRoot;
        }
    }
}

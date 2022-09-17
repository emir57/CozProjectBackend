using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CozProject.DataAccess.Config
{
    public sealed class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories")
                .HasKey(c => c.Id);

            builder.HasMany(c => c.Questions);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.BackgroundColor)
                .HasColumnName("BackgroundColor")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.TextColor)
                .HasColumnName("TextColor")
                .IsRequired()
                .HasMaxLength(20);

            builder.Ignore(c => c.IsComplete);

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate)
                .HasColumnName("DeletedDate");

            Category[] categoryEntitySeeds =
            {
                new Category(1,"C#","#26b628","#ffffff",DateTime.Now),
                new Category(2,"Javascript","#f7df1e","#ae9090",DateTime.Now)
            };
            builder.HasData(categoryEntitySeeds);
        }
    }
}

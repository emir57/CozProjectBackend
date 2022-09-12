using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
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

            builder.Ignore(c => c.isComplete);

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

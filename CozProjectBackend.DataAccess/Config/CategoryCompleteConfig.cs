using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProject.DataAccess.Config
{
    public sealed class CategoryCompleteConfig : IEntityTypeConfiguration<CategoryComplete>
    {
        public void Configure(EntityTypeBuilder<CategoryComplete> builder)
        {
            builder.ToTable("CategoryCompletes")
                .HasKey(c => c.Id);

            builder.HasOne(c => c.User);
            builder.HasOne(c => c.Category);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(c => c.CategoryId)
                .IsRequired()
                .HasColumnName("CategoryId");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(c => c.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

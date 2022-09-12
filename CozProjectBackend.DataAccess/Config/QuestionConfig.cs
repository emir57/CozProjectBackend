using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
{
    public sealed class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions")
                .HasKey(q => q.Id);

            builder.HasOne(c => c.User);
            builder.HasOne(c => c.Category);
            builder.HasMany(c => c.Answers);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Content)
                .HasColumnName("Content");

            builder.Property(c => c.TeacherId)
                .HasColumnName("TeacherId");

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoryId");

            builder.Property(c => c.Score)
                .HasColumnName("Score");

            builder.Ignore(c => c.Result);

            builder.Property(a => a.CreatedDate)
               .HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate)
                .HasColumnName("DeletedDate");


        }
    }
}

using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProjectBackend.DataAccess.Config
{
    public sealed class AnswerConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers")
                .HasKey(a => a.Id);

            builder.HasOne(a => a.Question);

            builder.Property(a => a.Id)
                .HasColumnName("Id");

            builder.Property(a => a.QuestionId)
                .HasColumnName("QuestionId")
                .IsRequired();

            builder.Property(a => a.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.IsTrue)
                .HasColumnName("IsTrue");

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozProject.DataAccess.Config
{
    public sealed class QuestionCompleteConfig : IEntityTypeConfiguration<QuestionComplete>
    {
        public void Configure(EntityTypeBuilder<QuestionComplete> builder)
        {
            builder.ToTable("QuestionCompletes")
                .HasKey(q => q.Id);

            builder.HasOne(q => q.User);
            builder.HasOne(q => q.Question);

            builder.Property(q => q.Id)
                .HasColumnName("Id");

            builder.Property(q => q.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(q => q.QuestionId)
                .IsRequired()
                .HasColumnName("QuestionId");

            builder.Property(q => q.Result)
                .HasColumnName("Result");

            builder.Property(q => q.CreatedDate)
                .HasColumnName("CreatedDate");
            builder.Property(q => q.UpdatedDate)
                .HasColumnName("UpdatedDate");
            builder.Property(q => q.DeletedDate)
                .HasColumnName("DeletedDate");
        }
    }
}

using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CozProject.DataAccess.Config
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

            Answer[] answerEntitySeeds =
            {
                new Answer(1,1,"Where();",false,DateTime.Now),
                new Answer(2,1,"ToList();",false,DateTime.Now),
                new Answer(3,1,"Select();",false,DateTime.Now),
                new Answer(4,1,"Skip();",false,DateTime.Now),
                new Answer(5,1,"SingleOrDefault();",true,DateTime.Now),
                new Answer(6,2,"System.Security.Cryptography",true,DateTime.Now),
                new Answer(7,2,"Security.Cryptography",false,DateTime.Now),
                new Answer(8,2,"System.Cryptography",false,DateTime.Now),
                new Answer(9,3,"delete",true,DateTime.Now),
                new Answer(10,3,"unbind",false,DateTime.Now),
                new Answer(11,3,"remove",false,DateTime.Now),
                new Answer(12,4,"pop",true,DateTime.Now),
                new Answer(13,4,"slice",false,DateTime.Now),
                new Answer(14,4,"splice",false,DateTime.Now),
                new Answer(15,4,"remove",false,DateTime.Now),
            };
            builder.HasData(answerEntitySeeds);
        }
    }
}

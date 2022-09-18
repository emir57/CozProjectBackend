using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozProject.Entities.Concrete;

public class Question : IEntity
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }

    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public User User { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<Answer> Answers { get; set; }

    public bool? Result { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Question()
    {
        Answers = new HashSet<Answer>();
    }

    public Question(int id, string content, int score, int teacherId, int categoryId, DateTime? createdDate) : this()
    {
        Id = id;
        Content = content;
        Score = score;
        TeacherId = teacherId;
        CategoryId = categoryId;
        CreatedDate = createdDate;
    }
}

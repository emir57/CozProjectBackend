using Core.Entities;
using System;

namespace CozProject.Entities.Concrete;

public class Answer : IEntity
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public string Content { get; set; }
    public bool IsTrue { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Answer()
    {
        Question = new Question();
    }

    public Answer(int id, int questionId, string content, bool isTrue, DateTime? createdDate) : this()
    {
        Id = id;
        QuestionId = questionId;
        Content = content;
        IsTrue = isTrue;
        CreatedDate = createdDate;
    }
}

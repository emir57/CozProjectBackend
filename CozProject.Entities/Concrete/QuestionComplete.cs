using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace CozProject.Entities.Concrete;

public class QuestionComplete : IEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public bool? Result { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

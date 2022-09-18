using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace CozProject.Entities.Concrete;

public class CategoryComplete : IEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

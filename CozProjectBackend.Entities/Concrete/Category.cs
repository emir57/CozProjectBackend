using Core.Entities;
using System;
using System.Collections.Generic;

namespace CozProject.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public bool isComplete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Category()
        {
            Questions = new HashSet<Question>();
        }

        public Category(int id, string name, string backgroundColor, string textColor, DateTime? createdDate) : this()
        {
            Id = id;
            Name = name;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            CreatedDate = createdDate;
        }
    }
}

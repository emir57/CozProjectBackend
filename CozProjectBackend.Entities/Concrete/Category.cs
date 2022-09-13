using Core.Entities;
using System;
using System.Collections.Generic;

namespace CozProjectBackend.Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public bool isComplete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}

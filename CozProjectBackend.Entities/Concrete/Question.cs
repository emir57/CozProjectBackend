using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

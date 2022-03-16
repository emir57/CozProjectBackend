using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Entities.Concrete
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsTrue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

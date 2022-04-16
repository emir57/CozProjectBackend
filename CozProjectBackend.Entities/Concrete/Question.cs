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
        public int TeacherId { get; set; }
        public int CategoryId { get; set; }
        public int Score { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CozProjectBackend.Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int Score { get; set; }
        [NotMapped]
        public List<Answer> Answers { get; set; }
        [NotMapped]
        public bool? Result { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

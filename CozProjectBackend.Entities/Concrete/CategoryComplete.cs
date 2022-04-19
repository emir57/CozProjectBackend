using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Entities.Concrete
{
    public class CategoryComplete : IEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set ; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

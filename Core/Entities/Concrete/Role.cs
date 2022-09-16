using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Role(int id, string name, DateTime? createdDate) : this()
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete;

public class UserRole : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    public UserRole()
    {
        User = new User();
        Role = new Role();
    }

    public UserRole(int id, int userId, int roleId, DateTime? createdDate)
    {
        Id = id;
        UserId = userId;
        RoleId = roleId;
        CreatedDate = createdDate;
    }
}

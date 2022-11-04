using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete;

public class User : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool EmailConfirmed { get; set; }
    public int Score { get; set; }
    public Uri ProfilePhotoUrl { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public User()
    {
        UserRoles = new HashSet<UserRole>();
    }

    public User(int id, string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt, bool emailConfirmed, int score, Uri profilePhotoUrl, DateTime? createdDate) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        EmailConfirmed = emailConfirmed;
        Score = score;
        ProfilePhotoUrl = profilePhotoUrl;
        CreatedDate = createdDate;
    }
}

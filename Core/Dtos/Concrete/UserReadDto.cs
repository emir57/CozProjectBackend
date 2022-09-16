using Core.Dtos.Abstract;
using System;

namespace Core.Dtos.Concrete
{
    public sealed class UserReadDto : IReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public string ProfilePhotoUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

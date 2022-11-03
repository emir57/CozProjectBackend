using Core.Dtos.Abstract;
using System.Collections.Generic;

namespace Core.Dtos.Concrete
{
    public sealed class UpdateUserAdminDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Score { get; set; }
        public System.Uri ProfilePhotoUrl { get; set; }
        public List<UpdateRoleDto> Roles { get; set; }
    }
}

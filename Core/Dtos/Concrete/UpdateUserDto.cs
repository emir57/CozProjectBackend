using Core.Dtos.Abstract;

namespace Core.Dtos.Concrete
{
    public sealed class UpdateUserDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

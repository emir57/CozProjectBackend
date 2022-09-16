using Core.Dtos.Abstract;

namespace Core.Dtos.Concrete
{
    public sealed class UserForRegisterDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

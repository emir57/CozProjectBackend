using Core.Entities.Dtos.Abstract;
using Core.Utilities.Security.JWT;

namespace Core.Entities.Dtos.Concrete
{
    public sealed class LoginResponseDto : IDto
    {
        public UserReadDto User { get; set; }
        public AccessToken Token { get; set; }
    }
}

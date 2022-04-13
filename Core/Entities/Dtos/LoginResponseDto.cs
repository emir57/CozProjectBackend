using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class LoginResponseDto : IDto
    {
        public LoginedUserDto User { get; set; }
        public AccessToken Token { get; set; }
    }
}

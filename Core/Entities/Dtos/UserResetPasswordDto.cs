using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UserResetPasswordDto : IDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

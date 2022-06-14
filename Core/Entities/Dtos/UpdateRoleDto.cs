using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UpdateRoleDto : IDto
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
    }
}

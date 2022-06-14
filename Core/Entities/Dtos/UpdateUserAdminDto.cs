﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UpdateUserAdminDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Score { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public int[] Roles { get; set; }
    }
}
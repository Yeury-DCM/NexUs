﻿using NexUs.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Dtos.Account
{
    public class UpdateUserRequest
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<UserViewModel> Friends { get; set; }
        public string ImagePath { get; set; }
        public string PhoneNumber { get; set; }
    }
}

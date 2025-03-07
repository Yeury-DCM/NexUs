using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string? ImagePath { get; set; }

        public string PhoneNumber { get; set; }

        public List<UserViewModel> Friends { get; set; }

    }
}

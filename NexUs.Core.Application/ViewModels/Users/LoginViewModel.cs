﻿using System.ComponentModel.DataAnnotations;

namespace NexUs.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre de usuario")]
        [DataType(DataType.Text)]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}

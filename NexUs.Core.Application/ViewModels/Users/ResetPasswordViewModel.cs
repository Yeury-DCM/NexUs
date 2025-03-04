using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NexUs.Core.Application.ViewModels.Users
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Ingrese el Email")]
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }

        [Required(ErrorMessage = "Debe tener un token")]
        [DataType(DataType.EmailAddress)]
        public  string Token { get; set; }



        [Required(ErrorMessage = "Ingrese la contraseña")]
        [DataType(DataType.Password)]
        public  string Password { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Las contraaseñas deben coincidir")]
        public string ConfirmPassword { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}

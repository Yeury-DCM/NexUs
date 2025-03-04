using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.ViewModels.Users
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Ingrese el apellido.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Ingrese el email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ingrese el nombre de usuario.")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Ingrese la contraseña.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Ingrese la confirmación de contraseña.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "La contraseñas deben coincidir")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Ingrese el nombre.")]
        [DataType(DataType.Text)]
        public string ImagePath { get; set; }


        [Required(ErrorMessage = "Ingrese el nombre.")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }


        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Suba su foto de perfil.")]
        public IFormFile File { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}

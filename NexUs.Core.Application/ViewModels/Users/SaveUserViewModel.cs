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
    public class SaveUserViewModel
    {

        public string Id { get; set; }

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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo una minúscula, una mayúscula, un número y un carácter especial.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Ingrese la confirmación de contraseña.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "La contraseñas deben coincidir")]
        public string ConfirmPassword { get; set; }

        public string? ImagePath { get; set; }

      
        [RegularExpression(@"^(809|829|849)\d{7}$", ErrorMessage = "El número de teléfono debe estar en el formato válido para RD (ej. 8091234567).")]
        [Required(ErrorMessage = "Ingrese el numero telefónico.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Suba su foto de perfil.")]
        public IFormFile File { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}

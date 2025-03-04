
using System.ComponentModel.DataAnnotations;

namespace NexUs.Core.Application.ViewModels.Users
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Ingrese el correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace NexUs.Core.Application.ViewModels.Friends
{
    public class AddFriendViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre de usuario")]
        public string UserName { get; set; }
        public string? Message { get; set; }
        public bool Sucess { get; set; } = true;
    }
}

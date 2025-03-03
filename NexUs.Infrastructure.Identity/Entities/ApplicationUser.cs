using Microsoft.AspNetCore.Identity;

namespace NexUs.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string ImagePath {  get; set; }
        public string? IdentificationNumebr {  get; set; }

    }
}

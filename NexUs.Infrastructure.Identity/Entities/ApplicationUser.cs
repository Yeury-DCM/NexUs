using Microsoft.AspNetCore.Identity;
using NexUs.Core.Domain.Entities;

namespace NexUs.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ImagePath {  get; set; }

        public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}

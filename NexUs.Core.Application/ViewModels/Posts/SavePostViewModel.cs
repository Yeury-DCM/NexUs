

using Microsoft.AspNetCore.Http;
using NexUs.Core.Application.Interfaces.Services;

namespace NexUs.Core.Application.ViewModels.Posts
{
    public class SavePostViewModel : IHasId
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? VideoPath { get; set; }
        public DateTime DateTime { get; set; }
        public string? UserId { get; set; }
    }
}



using Microsoft.AspNetCore.Http;

namespace NexUs.Core.Application.ViewModels.Posts
{
    public class SavePostViewModel
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        IFormFile ImageFile { get; set; }
        public string? VideoPath { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
    }
}

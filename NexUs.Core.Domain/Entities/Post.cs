
namespace NexUs.Core.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}

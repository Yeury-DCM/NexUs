
namespace NexUs.Core.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? PostId { get; set; } // FK
        public int? ParentCommentId { get; set; } //FK

        public string UserId { get; set; }//fk
        //Navegation Properties
        public Post? Post { get; set; }
        public Comment? ParentComment { get; set; }
        public List<Comment> Answers { get; set; } = new();

    }
}

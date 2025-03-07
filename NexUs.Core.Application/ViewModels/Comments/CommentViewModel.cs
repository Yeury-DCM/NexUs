using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Users;
using NexUs.Core.Domain.Entities;

namespace NexUs.Core.Application.ViewModels.Comments
{
    public class CommentViewModel : IHasId
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int ParentCommentId { get; set; }
        public UserViewModel User { get; set; }
        public List<CommentViewModel> Answers { get; set; } = new();
      
    }
}

using NexUs.Core.Application.ViewModels.Comments;
using NexUs.Core.Application.ViewModels.Users;
using NexUs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public UserViewModel User { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}

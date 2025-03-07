using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.ViewModels.Friends
{
    public class FriendsAndPostsViewModel
    {
        public List<UserViewModel> Friends { get; set; }
        public List <PostViewModel> Posts { get; set; }
    }
}

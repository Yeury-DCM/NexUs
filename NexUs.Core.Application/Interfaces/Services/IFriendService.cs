
using NexUs.Core.Application.ViewModels.Friends;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IFriendService
    {
        Task<FriendsAndPostsViewModel> GetFriendsAndPostsAsync(string userId);
        Task RemoveFriend(string MainUserId, string FriendId);
    }
}

using AutoMapper;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Friends;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.Services
{
    public class FriendService : IFriendService
    {
        IUserService _userService;
        IPostService _postService;
        IMapper _mapper;

        public FriendService(IUserService userService, IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<FriendsAndPostsViewModel> GetFriendsAndPostsAsync(string userId)
        {
            List<UserViewModel> friends = await _userService.GetFriendsAsync(userId);

            List<PostViewModel> AllFriendsPosts = new();

            foreach (var friend in friends)
            {
                List<PostViewModel> friendPosts = await _postService.GetAllViewModelByUser(friend.Id);
                AllFriendsPosts.AddRange(friendPosts);
            }

            FriendsAndPostsViewModel friendsAndPostsViewModel = new FriendsAndPostsViewModel()
            {
                Friends = friends,
                Posts = AllFriendsPosts.OrderByDescending(p => p.DateTime).ToList()
            };

            return friendsAndPostsViewModel;
        }

        public async Task RemoveFriend(string mainUserId, string friendId)
        {
            UserViewModel mainUser = await _userService.GetById(mainUserId);
            UserViewModel friend = await _userService.GetById(friendId);

            mainUser.Friends.RemoveAll(f => f.Id == friendId);
            friend.Friends.RemoveAll(m => m.Id == mainUserId );

            SaveUserViewModel updateMainUserRequest = _mapper.Map<SaveUserViewModel>(mainUser);
            SaveUserViewModel UpdateFriendRequest = _mapper.Map<SaveUserViewModel>(friend);

            await _userService.UpdateUserAsync(updateMainUserRequest);
            await _userService.UpdateUserAsync(UpdateFriendRequest);

        }

        public async Task<AddFriendViewModel> AddFriend(string mainUserId, string friendUserName)
        {
            AddFriendViewModel addFriendViewModel = new();

            UserViewModel mainUser = await _userService.GetById(mainUserId);
            UserViewModel friend = await _userService.GetByUsername(friendUserName);

            if(friend == null)
            {
                addFriendViewModel.Sucess = false;
                addFriendViewModel.Message = "El usuario no existe.";
                return addFriendViewModel;
            }

            if (mainUser.Friends.Any( f => f.Id == friend.Id))
            {
                addFriendViewModel.Sucess = false;
                addFriendViewModel.Message = $"Tu y {friend.FirstName} ya son amigos.";
                return addFriendViewModel;
            }

            mainUser.Friends.Add(friend);
            friend.Friends.Add(mainUser);


            SaveUserViewModel updateMainUserRequest = _mapper.Map<SaveUserViewModel>(mainUser);
            SaveUserViewModel UpdateFriendRequest = _mapper.Map<SaveUserViewModel>(friend);

            var updateMainUserResponse = await _userService.UpdateUserAsync(updateMainUserRequest);
            var updateFriendResponse = await _userService.UpdateUserAsync(UpdateFriendRequest);

            addFriendViewModel.Sucess = !updateMainUserResponse.HasError && !updateFriendResponse.HasError;

            if (!addFriendViewModel.Sucess)
                addFriendViewModel.Message = "Ocurrió un error agregando al usuario como amigo";

            return addFriendViewModel;
        }
    }
}

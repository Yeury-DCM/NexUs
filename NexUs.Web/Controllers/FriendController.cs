using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Helpers;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.Helpers;

namespace NexUs.Web.Controllers
{
    public class FriendController : Controller
    {
        IFriendService _friendsService;
        IHttpContextAccessor _httpContextAccessor;
        AuthenticationResponse _user;

        public FriendController(IFriendService friendService, IHttpContextAccessor httpContextAccessor)
        {
            _friendsService = friendService;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext!.Session.Get<AuthenticationResponse>("user")!;
        }
        public async Task<IActionResult> Index()
        {

            AuthenticationResponse user = _httpContextAccessor.HttpContext!.Session.Get<AuthenticationResponse>("user")!;

            var FriendsAndPosts = await _friendsService.GetFriendsAndPostsAsync(user.Id);

            return View(FriendsAndPosts);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFriend(string id)
        {
            await _friendsService.RemoveFriend(_user.Id, id);
            return RedirectToAction("Index");
        }
    }
}

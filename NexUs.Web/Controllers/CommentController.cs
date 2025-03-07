using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Helpers;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Comments;

namespace NexUs.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        AuthenticationResponse _user;


        public CommentController(ICommentService commentService, IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext!.Session.Get<AuthenticationResponse>("user")!;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment (int postId, string content, int parentCommentId, bool commentFromAFriend = false)
        {
            ModelState.Remove("Id");
            SaveCommentViewModel viewModel = new()
            {
                PostId = postId,
                Content = content,
                UserId = _user.Id,
                ParentCommentId = parentCommentId == 0? null : parentCommentId


            };

            await _commentService.Add(viewModel);
            
            
   
            return RedirectToRoute(new { Controller = commentFromAFriend? "Friend" : "Home", action = "Index" });

        }

    }
}

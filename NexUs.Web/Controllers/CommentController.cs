using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Comments;

namespace NexUs.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment (int postId, string content, int parentCommentId)
        {
            SaveCommentViewModel viewModel = new()
            {
                PostId = postId,
                Content = content,
                UserId = "861d379c-89d0-4d5c-beb3-50757b3b19d5",
                ParentCommentId = parentCommentId
                
            };

            await _commentService.Add(viewModel);
            

            return RedirectToRoute(new { Controller = "Home", action = "Index" });

        }

    }
}

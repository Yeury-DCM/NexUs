using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Email;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.Services;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Web.Models;
using System.Diagnostics;

namespace NexUs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IPostService _postService;


        public HomeController(IPostService postService, ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            List<PostViewModel> posts = await _postService.GetAllViewModel();
            return View(posts);
        }

        public  IActionResult AddPost()
        {
            return View("SavePost");
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(SavePostViewModel savePostViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("SavePost", savePostViewModel);
            }
            return View("SavePost");
        }


        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

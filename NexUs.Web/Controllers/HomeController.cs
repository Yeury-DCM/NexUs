using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Helpers;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Friends;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Web.Models;
using System.Diagnostics;

namespace NexUs.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AuthenticationResponse _user;



        public HomeController(IPostService postService, ILogger<HomeController> logger, IEmailService emailService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _logger = logger;
            _emailService = emailService;
            _postService = postService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext!.Session.Get<AuthenticationResponse>("user")!;

        }

        public async Task<IActionResult> Index()
        {

            List<PostViewModel> posts = await _postService.GetAllViewModelByUser(_user.Id);
            return View(posts);
        }

        public  IActionResult Add()
        {
            return View("SavePost");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SavePostViewModel savePostViewModel)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateTime");


            if (!ModelState.IsValid)
            {
                return View("SavePost", savePostViewModel);
            }

            savePostViewModel.UserId = _user.Id;
            savePostViewModel.DateTime = DateTime.Now;
            SavePostViewModel savedPost = await _postService.Add(savePostViewModel);
           

            if(savePostViewModel.ImageFile != null)
            {
                string imagePath = UploadFile(savePostViewModel.ImageFile!, (int)savedPost.Id!);
                savedPost.ImagePath = imagePath;
                await _postService.Update(savedPost);

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            return View("SavePost", await _postService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePostViewModel savePostViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("SavePost", savePostViewModel);
            }


            if (savePostViewModel.ImageFile != null)
            {
                string imagePath = UploadFile(savePostViewModel.ImageFile!, (int)savePostViewModel.Id!, true, savePostViewModel.ImagePath!);
                savePostViewModel.ImagePath = imagePath;
            }

            await _postService.Update(savePostViewModel);

           return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _postService.Delete(id);

            //Get Directory Path
            string basePath = $"/images/Posts/{id}";
            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{basePath}";

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete();
                }

                Directory.Delete(path, true);

            }
            return RedirectToAction("Index");


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


        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {


            if (isEditMode && file == null)
            {
                return imagePath;
            }

            //Get Directory Path
            string basePath = $"/images/Posts/{id}";
            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{basePath}";

            //Create folder if no exists

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Get File Path

            Guid guid = Guid.NewGuid();
            var fileInfo = new FileInfo(file.FileName);
            string fileName = $"{guid}_{fileInfo.Name}";


            string fileNameWithPath = $"{path}/{fileName}";


            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode && !string.IsNullOrWhiteSpace(imagePath))
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImageName = oldImagePart[^1];
                string imageCompleteOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(imageCompleteOldPath))
                {
                    System.IO.File.Delete(imageCompleteOldPath);
                }

            }

            return $"{basePath}/{fileName}";
        }
    }
}

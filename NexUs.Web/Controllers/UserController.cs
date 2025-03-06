
using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Users;
using NexUs.Core.Application.Helpers;

namespace NexUs.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            AuthenticationResponse authenticationResponse = await _userService.LoginAsync(loginViewModel);

            if (authenticationResponse != null && !authenticationResponse.HasError)
            {
                _httpContextAccessor.HttpContext!.Session.Set<AuthenticationResponse>("user", authenticationResponse);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                loginViewModel.HasError = true;
                loginViewModel.Error = authenticationResponse!.Error;
                return View(loginViewModel);
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");

           return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel saveUserViewModel)
        {
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                return View(saveUserViewModel);
            }

            var origin = Request.Headers["origin"];
            RegisterResponse response = await _userService.RegisterAsync(saveUserViewModel, origin);


            if (response.HasError)
            {
                saveUserViewModel.HasError = response.HasError;
                saveUserViewModel.Error = response.Error;
                return View(saveUserViewModel);
            }

            string imagePath = UploadFile(saveUserViewModel.File, response.UserId);

            saveUserViewModel.ImagePath = imagePath;

            saveUserViewModel.Id = response.UserId;

            UpdateUserResponse updateUserResponse = await _userService.UpdateUserAsync(saveUserViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await _userService.ConfirmEmailAsync(userId, token);      
            return View("ConfirmEmail", response);
        }

        public IActionResult ForgotPassword()
        {

            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordViewModel);
            }

            var origin = Request.Headers["origin"];
            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(forgotPasswordViewModel, origin);
            
            if (response.HasError)
            {
                forgotPasswordViewModel.HasError = response.HasError;
                forgotPasswordViewModel.Error = response.Error;
                return View(forgotPasswordViewModel);
            }
   
            return RedirectToAction("Index");
        }

      

        private string UploadFile(IFormFile file, string id, bool isEditMode = false, string imagePath = "")
        {


            if (isEditMode && file == null)
            {
                return imagePath;
            }

            //Get Directory Path
            string basePath = $"/images/Users/{id}";
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

            if (isEditMode)
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

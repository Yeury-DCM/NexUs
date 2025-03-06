
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Users;
using NexUs.Infrastructure.Identity.Entities;
using System.Text;

namespace NexUs.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;


        public AccountService(IEmailService emailService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No Accounts registered with {request.UserName}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid credentials for {request.UserName}";
                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Account not confirmed for {request.UserName}";
                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;


            return response;
        }

        public async Task SingOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<RegisterResponse> RegisterUser(RegisterRequest request, string origin)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);

            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Username '{request.UserName}' is already taken.";
                return response;
            }

            var userWithSameUserEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.UserName}' is already taken.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName.Trim(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                PhoneNumber = request.PhoneNumber

            };

            var result = await _userManager.CreateAsync(user, request.Password);


            if (result.Succeeded)
            {
                response.UserId = user.Id;
                var verificationUri = await SendVerificationEmailUrl(user, origin);
                await _emailService.SendAsync(new Core.Application.Dtos.Email.EmailRequest()
                {
                    To = user.Email,
                    Subject = "One last step: Verify your email",
                    Body = $"Please confirm your account visiting this link:\n {verificationUri}"
                });
            }
            else
            {
                response.HasError = true;
                response.Error = $"An error occurred trying to register the user.";
                return response;
            }

            return response;
        }

        public async Task<string> ConfirmAccountAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return "No account registred with this user";
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, token); 
            if (result.Succeeded)
            { 
                return $"Account confirmed for {user.Email}. You can now use the app.";
            }
            else
            {
                return "An error occurred trying to register the user.";

            }
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
        {
            ForgotPasswordResponse response = new();
            response.HasError = false;

            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No user registered with {request.Username}";
                return response;
            }

            string generatedPassword = GeneratePassword(8);
            var removePasswordResult = await _userManager.RemovePasswordAsync(user);
            var setPasswordResult = await _userManager.AddPasswordAsync(user, generatedPassword);

          
            await _emailService.SendAsync(new Core.Application.Dtos.Email.EmailRequest()
            {
                To = user.Email!,
                Subject = "Reset password",
                Body = $"Hi {user.FirstName}, your new password is: {generatedPassword}"
            });

            return response;
        }  


        private async Task<string> SendVerificationEmailUrl(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ConfirmEmail";
            var uri = new Uri($"{origin.TrimEnd('/')}/{route}");
            var verificationUrl = QueryHelpers.AddQueryString(uri.ToString(), "userId", user.Id);
            verificationUrl = QueryHelpers.AddQueryString(verificationUrl, "token", code);


            return verificationUrl;
        }


        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request)
        {
            UpdateUserResponse response = new() { HasError = false };
          

            ApplicationUser? user =await _userManager.FindByIdAsync(request.UserId);

            if(user == null)
            {
                response.HasError = true;
                response.Error = "No se encontró el usuario";
                return response;
            }


            

            user.ImagePath = request.ImagePath;

            if (!user.EmailConfirmed)
            {
                var resultUpdateImage = await _userManager.UpdateAsync(user);
                if (!resultUpdateImage.Succeeded)
                {
                    response.HasError = true;
                    response.Error = "An error ocurred updating the user profile photo.";
                }

                return response;
            }


            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;          
            user.PhoneNumber = request.PhoneNumber;

            if (request.Password != null)
            {
                var resultRemovePassword = await _userManager.RemovePasswordAsync(user);
                var resultAddPassword = await _userManager.AddPasswordAsync(user, request.Password);

                if (!resultAddPassword.Succeeded || !resultRemovePassword.Succeeded)
                {
                    response.HasError = true;
                    response.Error = "An error ocurred updating the password.";
                }
            }

            var resultUpdate = await _userManager.UpdateAsync(user);

            if (!resultUpdate.Succeeded)
            {
                response.HasError = true;
                response.Error = "An error ocurred updating the user.";
            }


            return response;
        }

       

        private string GeneratePassword(int requiredLength)
        {
            string password = "";
            Random rnd = new Random();


            while (password.Length < requiredLength)
            {
                password += ((char)rnd.Next(97, 123)); // 'a' - 'z'
                password += ((char)rnd.Next(48, 57)); // '0' - '9'
                password += ((char)rnd.Next(65, 91));// 'A' - 'Z'
                password +=((char)rnd.Next(33, 48));// Special character
            }


            return password;
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);
            UserViewModel userViewModel = new()
            {
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                FirstName = user.FirstName,
                ImagePath = user.ImagePath,
                PhoneNumber = user.PhoneNumber
            };
            return userViewModel;
        }
    }

}

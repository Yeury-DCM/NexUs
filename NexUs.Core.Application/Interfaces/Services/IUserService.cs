using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel forgotPasswordViewModel, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel loginViewModel);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel registerViewModel, string origin);
        Task<UpdateUserResponse> UpdateUserAsync(SaveUserViewModel saveUserViewModel);
        Task SignOutAsync();

        Task<UserViewModel> GetById(string id);
        Task<SaveUserViewModel> GetByIdSaveViewModel(string id);

        Task<List<UserViewModel>> GetFriendsAsync(string userId);
       
    }
}
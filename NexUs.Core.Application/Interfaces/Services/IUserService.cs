using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel forgotPasswordViewModel, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel loginViewModel);
        Task<RegisterResponse> RegisterAsync(RegisterViewModel registerViewModel, string origin);
        Task SignOutAsync(ResetPasswordViewModel forgotPasswordViewModel);
    }
}
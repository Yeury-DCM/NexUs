using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterUser(RegisterRequest request, string origin);
        Task <UpdateUserResponse> UpdateUserAsync (UpdateUserRequest request);
        Task SingOutAsync();

        Task<UserViewModel> GetUserById(string id);
    }
}
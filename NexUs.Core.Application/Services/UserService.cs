using AutoMapper;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel loginViewModel)
        {
            AuthenticationRequest request = _mapper.Map<AuthenticationRequest>(loginViewModel);
            AuthenticationResponse response = await _accountService.AuthenticateAsync(request);

            return response;
        }

         
        public async Task SignOutAsync()
        {
            await _accountService.SingOutAsync();

        }

        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel registerViewModel, string origin)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(registerViewModel);
            RegisterResponse response = await _accountService.RegisterUser(request, origin);

            return response;

        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountService.ConfirmAccountAsync(userId, token);
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel forgotPasswordViewModel, string origin)
        {
            ForgotPasswordRequest request = _mapper.Map<ForgotPasswordRequest>(forgotPasswordViewModel);
            ForgotPasswordResponse response = await _accountService.ForgotPasswordAsync(request, origin);

            return response;

        }

        public async Task<UpdateUserResponse> UpdateUserAsync (SaveUserViewModel saveUserViewModel)
        {
            UpdateUserRequest request = _mapper.Map<UpdateUserRequest>(saveUserViewModel);
            UpdateUserResponse response = await _accountService.UpdateUserAsync(request);

            return response;
        }

        public Task<UserViewModel> GetById(string id)
        {
            return _accountService.GetUserById(id);
        }
    }
}

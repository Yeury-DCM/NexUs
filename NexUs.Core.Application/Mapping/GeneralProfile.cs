
using AutoMapper;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.ViewModels.Users;

namespace NexUs.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.Error, otp => otp.Ignore())
                .ForMember(x => x.HasError, otp => otp.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, RegisterViewModel>()
               .ForMember(x => x.Error, otp => otp.Ignore())
               .ForMember(x => x.HasError, otp => otp.Ignore())
               .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
               .ForMember(x => x.Error, otp => otp.Ignore())
               .ForMember(x => x.HasError, otp => otp.Ignore())
               .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
             .ForMember(x => x.Error, otp => otp.Ignore())
             .ForMember(x => x.HasError, otp => otp.Ignore())
             .ReverseMap();
        }
    }
}

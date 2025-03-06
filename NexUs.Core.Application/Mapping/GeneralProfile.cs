
using AutoMapper;
using NexUs.Core.Application.Dtos.Account;
using NexUs.Core.Application.ViewModels.Comments;
using NexUs.Core.Application.ViewModels.Posts;
using NexUs.Core.Application.ViewModels.Users;
using NexUs.Core.Domain.Entities;

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

            CreateMap<RegisterRequest, SaveUserViewModel>()
               .ForMember(x => x.Error, otp => otp.Ignore())
               .ForMember(x => x.HasError, otp => otp.Ignore())
               .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
               .ForMember(x => x.Error, otp => otp.Ignore())
               .ForMember(x => x.HasError, otp => otp.Ignore())
               .ReverseMap();

            CreateMap<UpdateUserRequest, SaveUserViewModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom( src => src.UserId))
               .ForMember(x => x.Error, otp => otp.Ignore())
               .ForMember(x => x.HasError, otp => otp.Ignore())
               .ReverseMap();

            CreateMap<PostViewModel, Post>()
                .ReverseMap();

            CreateMap<SavePostViewModel, Post >()
                .ReverseMap();

            CreateMap<CommentViewModel, Comment>()
                .ReverseMap();

            CreateMap<SaveCommentViewModel, Comment>()
                .ReverseMap();
            
        }
    }
}

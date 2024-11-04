using AutoMapper;
using Ridel.Application.DTOs.Auth;

namespace Ridel.Application.Mappings.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterRequest, Ridel.Domain.Entities.User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}

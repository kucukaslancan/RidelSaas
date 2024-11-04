using AutoMapper;
using Ridel.Application.DTOs.User;
using Ridel.Domain.Entities;

namespace Ridel.Application.Mappings.User
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<Domain.Entities.User, UserInfoDTO>()
             .ForMember(dest => dest.UserDetail, opt => opt.MapFrom(src => new UserDetailDTO
             {
                 CompanyName = src.UserDetail.CompanyName,
                 EIN = src.UserDetail.EIN,
                 CompanyAddress = src.UserDetail.CompanyAddress,
                 ContactPerson = src.UserDetail.ContactPerson,
                 CompanyPhoneNumber = src.UserDetail.CompanyPhoneNumber,
                 CompanyEmail = src.UserDetail.CompanyEmail,
                 BirthDate = src.UserDetail.BirthDate,
                 WorkRegion = src.UserDetail.WorkRegion
             }));

        }
    }
}

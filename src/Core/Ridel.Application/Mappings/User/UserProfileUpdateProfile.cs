using AutoMapper;
using Ridel.Application.CQRS.Commands.Users;
using Ridel.Application.DTOs.Auth;
using Ridel.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.Mappings.User
{
    public class UserProfileUpdateProfile : Profile
    {
        public UserProfileUpdateProfile()
        {
            //CreateMap<UpdateUserProfileCommand, Ridel.Domain.Entities.User>()
            //  .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //   .ForMember(dest => dest.ProfilePhotoUrl, opt => opt.MapFrom(src => src.ProfilePhoto));

            // UpdateUserProfileCommand -> User mapping
            CreateMap<UpdateUserProfileCommand, Domain.Entities.User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ProfilePhotoUrl, opt => opt.MapFrom(src => src.ProfilePhoto));

            // UserDetailDTO -> UserDetail mapping
            CreateMap<UserDetailDTO, Domain.Entities.UserDetail>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.EIN, opt => opt.MapFrom(src => src.EIN))
                .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(src => src.CompanyAddress))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPerson))
                .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.CompanyPhoneNumber))
                .ForMember(dest => dest.CompanyEmail, opt => opt.MapFrom(src => src.CompanyEmail))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.WorkRegion, opt => opt.MapFrom(src => src.WorkRegion));

            // Eğer ters mapping'e de ihtiyaç duyulursa
            CreateMap<Domain.Entities.UserDetail, UserDetailDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.EIN, opt => opt.MapFrom(src => src.EIN))
                .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(src => src.CompanyAddress))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(src => src.ContactPerson))
                .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.CompanyPhoneNumber))
                .ForMember(dest => dest.CompanyEmail, opt => opt.MapFrom(src => src.CompanyEmail))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.WorkRegion, opt => opt.MapFrom(src => src.WorkRegion));
        }

    }
}

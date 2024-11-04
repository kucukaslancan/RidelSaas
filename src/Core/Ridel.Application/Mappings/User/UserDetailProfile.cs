using AutoMapper;
using Ridel.Application.CQRS.Commands.Users;
using Ridel.Domain.Entities;

namespace Ridel.Application.Mappings.User
{
    public class UserDetailProfile : Profile
    {
        public UserDetailProfile()
        {
            CreateMap<UpdateUserDetailCommand, UserDetail>();
        }
    }
}

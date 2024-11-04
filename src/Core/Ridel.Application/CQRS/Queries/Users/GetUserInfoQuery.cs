using MediatR;
using Ridel.Application.DTOs.User;
using Ridel.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ridel.Application.CQRS.Queries.Users
{
    public class GetUserInfoQuery : IRequest<RidelResponse<UserInfoDTO>>
    {
    }

}

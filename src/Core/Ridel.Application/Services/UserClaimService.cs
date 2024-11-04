using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Ridel.Application.Helpers;
using Ridel.Application.Interfaces.Services;
using Ridel.Domain.Entities;

namespace Ridel.Application.Services
{
    internal class UserClaimService : IUserClaimService
    {
        private readonly IdentityHelper _identityHelper;

       
        public UserClaimService(IdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }

       
        public async Task<string> GetCurrentUserIdAsync()
        {
            string? userId = _identityHelper.GetUserId();
            ArgumentNullException.ThrowIfNull(userId);

            return await Task.FromResult(userId);  
        }

       
        public async Task<string> GetCurrentUserRoleAsync()
        {
            string? userRole = _identityHelper.GetUserRole();
            return await Task.FromResult(userRole);
        }
    }
}

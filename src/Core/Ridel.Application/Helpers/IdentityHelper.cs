using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ridel.Application.Helpers
{
    public class IdentityHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string? userId = _httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value;

            return userId;
        }

        public string GetUserRole()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }
    }
}

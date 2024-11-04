using Ridel.Domain.Entities;
using Ridel.Domain.Entities.Jwt;

namespace Ridel.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        JwtSettings GetJwtSettings();
    }
}

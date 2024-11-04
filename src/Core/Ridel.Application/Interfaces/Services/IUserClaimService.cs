namespace Ridel.Application.Interfaces.Services
{
    public interface IUserClaimService
    {
        Task<string> GetCurrentUserIdAsync();
        Task<string> GetCurrentUserRoleAsync();
    }
}

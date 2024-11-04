using Ridel.Application.Interfaces.Repositories;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Domain.Entities;

namespace Ridel.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserClaimService _userClaimService;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserClaimService userClaimService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userClaimService = userClaimService;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserWithDetailsByIdAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUserDetailsAsync(UserDetail userDetails)
        {
            string? userId = await _userClaimService.GetCurrentUserIdAsync();

            UserDetail? existingDetails = await _unitOfWork.UserDetailRepository.GetAsync(d => d.UserId == userId);
            if (existingDetails != null)
            {
                existingDetails.CompanyName = userDetails.CompanyName;
                existingDetails.WorkRegion = userDetails.WorkRegion;
                // Diğer detayları güncelle
            }
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> HasUserDetailsAsync()
        {
            string? userId = await _userClaimService.GetCurrentUserIdAsync();
            return await _userRepository.HasUserDetails(userId);
        }

        public async Task DeleteUserAsync(string userId)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == userId);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}

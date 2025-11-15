using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByUserIdAsync(long userId);
        Task AddAsync(UserProfile profile);
    }
}

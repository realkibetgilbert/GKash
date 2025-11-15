using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id,CancellationToken ct = default);
        Task<User?> GetByPhoneAsync(string phoneNumber, CancellationToken ct = default);
        Task<User> CreateAsync(User user, CancellationToken ct = default);
        Task UpdateAsync(User user, CancellationToken ct = default);
    }
}

using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistance;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _ctx;
        public UserRepository(UserDbContext ctx) => _ctx = ctx;

        public async Task<User?> GetByPhoneAsync(string phoneNumber, CancellationToken ct = default)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber, ct);
        }

        public async Task<User> CreateAsync(User user, CancellationToken ct = default)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync(ct);
            return user;
        }

        public async Task UpdateAsync(User user, CancellationToken ct = default)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task<User?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
        }
    }
}

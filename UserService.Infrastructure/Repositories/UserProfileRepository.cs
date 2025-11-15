using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistance;

namespace UserService.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserDbContext _db;

        public UserProfileRepository(UserDbContext db)
        {
            _db = db;
        }

        public Task<UserProfile?> GetByUserIdAsync(long userId) =>
            _db.UserProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

        public async Task AddAsync(UserProfile profile)
        {
            await _db.UserProfiles.AddAsync(profile);
            await _db.SaveChangesAsync();
        }
    }
}

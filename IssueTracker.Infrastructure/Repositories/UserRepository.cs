using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return existingUser;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}

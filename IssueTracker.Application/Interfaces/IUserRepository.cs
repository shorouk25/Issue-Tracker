using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);

    }
}

using IssueTracker.Domain.Enums;
namespace IssueTracker.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(string userId, string email, Role role);
    }
}

using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Interfaces
{
    public interface IIssueRepository
    {
        Task<int> AddIssueAsync(Issue issue);
        Task DeleteIssueAsync(Issue issue);
        Task UpdateIssueAsync(Issue issue);
        Task UpdateAssigneeAsync(int issueId, string assigneeId);
        Task UpdateStatusAsync(int issueId, Status status);
        Task<Issue?> GetIssueByIdAsync(int issueId);
        Task<List<Issue>> GetIssuesByAssigneeAsync(string assigneeId);
        Task<List<Issue>> GetIssuesByReporterAsync(string reporterId);
        Task<List<Issue>> GetIssuesByProjectAsync(int projectId);
        Task<List<Issue>> SearchIssueByNameAsync(string name);
        Task<List<Issue>> GetAllIssuesAsync();
    }
}

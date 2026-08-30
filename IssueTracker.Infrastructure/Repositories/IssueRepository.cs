using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;
using IssueTracker.Domain.Enums;

namespace IssueTracker.Infrastructure.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly ApplicationDbContext _context;
        public IssueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddIssueAsync(Issue issue)
        {
            if(issue == null)
            {
                throw new ArgumentNullException(nameof(issue));
            }
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue.Id;
        }
        public Task DeleteIssueAsync(int issueId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Domain.Models.Issue>> GetAllIssuesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Domain.Models.Issue> GetIssueByIdAsync(int issueId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Domain.Models.Issue>> SearchIssueByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public Task UpdateIssueAsync(Domain.Models.Issue issue)
        {
            throw new NotImplementedException();
        }
        public Task UpdateStatusAsync(int issueId, Status status)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAssigneeAsync(int issueId, string assigneeId)
        {
            throw new NotImplementedException();
        }
    }
}

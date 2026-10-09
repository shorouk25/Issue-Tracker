using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;
using IssueTracker.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
            ArgumentNullException.ThrowIfNull(issue);
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue.Id;
        }
        public async Task DeleteIssueAsync(Issue issue)
        {
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Issue>> GetAllIssuesAsync()
        {
            var result = await _context.Issues.ToListAsync();
            return result;
        }
        public async Task<Issue?> GetIssueByIdAsync(int issueId)
        {
            var issue = await _context.Issues
                .Include(i => i.Labels)
                .FirstOrDefaultAsync(i => i.Id == issueId);
            return issue;
        }
        public async Task<List<Issue>> GetIssuesByAssigneeAsync(string assigneeId)
        {
            if(string.IsNullOrEmpty(assigneeId))
            {
                throw new ArgumentNullException(nameof(assigneeId));
            }

            var issues = await _context.Issues.
                Where(i => i.AssigneeId == assigneeId).
                OrderByDescending(i => i.CreatedAt).
                ToListAsync();
            return issues;
        }

        public async Task<List<Issue>> GetIssuesByReporterAsync(string reporterId)
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
        public async Task<List<Issue>> GetIssuesByProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
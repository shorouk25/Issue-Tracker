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
        { //display issue on the issue list page and for deleting the issue
            var issue = await _context.Issues
                .FirstOrDefaultAsync(i => i.Id == issueId);
            return issue;
        }
        public async Task<Issue?> GetIssueDetailsByIdAsync(int issueId)
        { //Get issue details to display on the issue details page and for editing the issue's info
            var issue = await _context.Issues
                .Include(i => i.Assignee)
                .Include(i => i.Reporter)
                .Include(i => i.Labels)
                .Include(i => i.Comments)
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
                Include(i => i.Project).
                Include(i => i.Reporter).
                Where(i => i.AssigneeId == assigneeId).
                OrderByDescending(i => i.CreatedAt).
                ToListAsync();
            return issues;
        }

        public async Task<List<Issue>> GetIssuesByReporterAsync(string reporterId)
        {
            if (string.IsNullOrEmpty(reporterId))
                throw new ArgumentNullException(nameof(reporterId));
            
            var issues = await _context.Issues.
                Include(i => i.Project).
                Where(i => i.ReporterId == reporterId).
                OrderByDescending(i => i.CreatedAt).
                ToListAsync();
            return issues;
        }
        public async Task<List<Issue>> SearchIssueByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            var existedIssues = await _context.Issues.Where(i => i.Name.Contains(name)).ToListAsync();
            return existedIssues;
        }
        public async Task UpdateIssueAsync(Issue issue)
        {
            ArgumentNullException.ThrowIfNull(issue);
            _context.Issues.Update(issue);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Issue>> GetIssuesByProjectAsync(int projectId)
        {
            var issues = await _context.Issues.
                Include(i => i.Project).
                Include(i => i.Reporter).
                Where(i => i.ProjectId == projectId).
                OrderByDescending(i => i.CreatedAt).
                ToListAsync();
            return issues;
        }
    }
}
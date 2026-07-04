using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Interfaces
{
    public interface IIssueRepository
    {
        Task<int> AddIssueAsync(Issue issue);
        Task DeleteIssueAsync(int issueId);
        Task UpdateIssueAsync(Issue issue);
        Task UpdateStatusAsync(int issueId, Status status);
        Task<Issue> GetIssueByIdAsync(int issueId);
        Task<List<Issue>> SearchIssueByNameAsync(string name);
        Task<List<Issue>> GetAllIssuesAsync();
    }
}

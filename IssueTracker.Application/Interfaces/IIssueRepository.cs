using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Interfaces
{
    public interface IIssueRepository
    {
        Task<int> AddAsync(Issue issue);
        Task DeleteAsync(int issueId);
        Task UpdateAsync(Issue issue);
        Task<Issue> GetIssueByIdAsync(int issueId);
    }
}

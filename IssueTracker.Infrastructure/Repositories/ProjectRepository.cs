using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;

namespace IssueTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Task<Project> GetProjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

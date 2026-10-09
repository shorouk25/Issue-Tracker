using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IProjectRepository _projectRepository;

        public CreateIssueCommandHandler(IIssueRepository issueRepository, IProjectRepository projectRepository)
        {
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            if(request.ProjectId.HasValue)
            {
                var project = await _projectRepository.GetProjectByIdAsync(request.ProjectId.Value);
                if (project == null)
                    throw new Exception("Project not found");
            }

            var newIssue = new Issue
            {
                Name = request.Name,
                Summary = request.Summary,
                Description = request.Description,
                Priority = request.Priority.HasValue? request.Priority.Value : Priority.Low,
                Status = request.Status.HasValue? request.Status.Value : Status.Open,
                Category = request.Category.HasValue? request.Category.Value : Category.None,
                AssigneeId = request.AssigneeId,
                ProjectId = request.ProjectId,
                ReporterId = request.ReporterId,
            };

            await _issueRepository.AddIssueAsync(newIssue);
            return newIssue.Id;
        }
    }
}

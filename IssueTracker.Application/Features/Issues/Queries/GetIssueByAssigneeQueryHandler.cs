using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssueByAssigneeQueryHandler : IRequestHandler<GetIssueByAssigneeQuery, List<IssueDto>>
    {
        private readonly IIssueRepository _issueRepository;
        public GetIssueByAssigneeQueryHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<List<IssueDto>> Handle(GetIssueByAssigneeQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetIssuesByAssigneeAsync(request.AssigneeId);
            return issues.Select(issue => new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                ProjectName = issue.Project != null ? issue.Project.Name : "No Project",
                Status = issue.Status,
                Priority = issue.Priority,
                ReporterName = issue.Reporter.FirstName + " " + issue.Reporter.LastName,
                ProjectId = issue.ProjectId,
                ReporterId = issue.ReporterId
            }).ToList();
        }
    }
}

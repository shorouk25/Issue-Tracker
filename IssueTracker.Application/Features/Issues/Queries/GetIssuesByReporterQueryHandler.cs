using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssuesByReporterQueryHandler : IRequestHandler<GetIssuesByReporterQuery, List<IssueDto>>
    {
        private readonly IIssueRepository _issueRepository;
        public GetIssuesByReporterQueryHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task<List<IssueDto>> Handle(GetIssuesByReporterQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetIssuesByReporterAsync(request.ReporterId);
            return issues.Select(issue => new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                Status = issue.Status,
                Priority = issue.Priority,
                ProjectId = issue.ProjectId,
                ProjectName = issue.Project != null ? issue.Project.Name : "No Project"
            }).ToList();
        }
    }
}
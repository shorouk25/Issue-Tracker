using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssuesByProjectQueryHandler: IRequestHandler<GetIssuesByProjectQuery, List<IssueDto>>
    {
        private readonly IIssueRepository _issueRepository;
        public GetIssuesByProjectQueryHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        //display all issues related to a specific project in page of the application
        public async Task<List<IssueDto>> Handle(GetIssuesByProjectQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetIssuesByProjectAsync(request.ProjectId);
            var issueDtos = issues.Select(issue => new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                ProjectId = issue.ProjectId,
                ProjectName = issue.Project != null ? issue.Project.Name : "No Project",
                ReporterId = issue.ReporterId,
                ReporterName = issue.Reporter.FirstName + " " + issue.Reporter.LastName,
                Status = issue.Status,
                Priority = issue.Priority
            }).ToList();
            return issueDtos;
        }
    }
}

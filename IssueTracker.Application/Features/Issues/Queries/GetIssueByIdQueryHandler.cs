using IssueTracker.Domain.Enums;
using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, IssueDetailsDto>
    {
        private readonly IIssueRepository _issueRepository;
        public GetIssueByIdQueryHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<IssueDetailsDto> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.Id);

            if (issue == null)
                throw new Exception("Issue not found");

            var issueDetailsDto = new IssueDetailsDto
            {
                Id = issue.Id,
                Name = issue.Name,
                Summary = issue.Summary,
                Description = issue.Description,
                CreatedDate = issue.CreatedAt,
                Status = issue.Status,
                Priority = issue.Priority.Value,
                Category = issue.Category.Value,
                AssigneeId = issue.AssigneeId,
                ProjectId = issue.ProjectId,
                Comments = issue.Comments,
                Attachments = issue.Attachments,
                Labels = issue.Labels
            };

            return issueDetailsDto;
        }
    }
}

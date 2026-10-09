using IssueTracker.Application.DTOs;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssueByAssigneeQuery : IRequest<List<IssueDto>>
    {
        public string AssigneeId { get; set; }
    }
}

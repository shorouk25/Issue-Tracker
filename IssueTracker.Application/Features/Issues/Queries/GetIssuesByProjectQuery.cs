using IssueTracker.Application.DTOs;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssuesByProjectQuery : IRequest<List<IssueDto>>
    {
        public int ProjectId { get; set; }
    }
}

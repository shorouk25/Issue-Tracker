using IssueTracker.Application.DTOs;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssueByIdQuery : IRequest<IssueDetailsDto>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class DeleteIssueCommand : IRequest
    {
        public int Id { get; set; }
    }
}

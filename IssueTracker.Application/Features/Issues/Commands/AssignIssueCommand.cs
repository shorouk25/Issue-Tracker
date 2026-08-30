using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class AssignIssueCommand : IRequest<int> //return id of the issue after assigning
    {
        public int Id { get; set; }
        public string AssigneeId { get; set; }
    }
}
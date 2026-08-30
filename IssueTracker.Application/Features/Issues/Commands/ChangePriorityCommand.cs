using IssueTracker.Domain.Enums;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangePriorityCommand : IRequest<int>
    {
        public int IssueId { get; set; }
        public Priority NewPriority { get; set; }
    }
}

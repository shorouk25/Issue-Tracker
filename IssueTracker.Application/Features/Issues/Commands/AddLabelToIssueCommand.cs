using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class AddLabelToIssueCommand : IRequest
    {
        public int IssueId { get; set; }
        public int LabelId { get; set; }
    }
}

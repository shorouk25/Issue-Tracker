using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class AddLabelToIssueCommand : IRequest
    {
        public int IssueId { get; set; }
        public int LabelId { get; set; }
    }
}

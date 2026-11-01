using MediatR;

namespace IssueTracker.Application.Features.Labels
{
    public class CreateLabelCommand : IRequest<int>
    {
        public required string Name { get; set; }
    }
}

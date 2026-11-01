using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class DeleteLabelCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

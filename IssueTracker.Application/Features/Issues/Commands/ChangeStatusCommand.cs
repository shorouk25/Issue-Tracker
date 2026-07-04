using IssueTracker.Domain.Enums;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangeStatusCommand : IRequest<int> //return id of the issue after changing status
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}

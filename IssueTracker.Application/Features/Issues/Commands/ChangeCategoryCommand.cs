using IssueTracker.Domain.Enums;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangeCategoryCommand : IRequest<int>
    {
        public int IssueId { get; set; }
        public Category NewCategory { get; set; }
    }
}

using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class CreateIssueCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public Category? Category { get; set; }
        public User? Assignee { get; set; }
        public int ProjectId { get; set; }
    }
}

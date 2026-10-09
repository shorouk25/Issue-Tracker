using MediatR;
using IssueTracker.Application.DTOs;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class SearchIssueQuery : IRequest<List<IssueDto>>
    {
        public string SearchTerm { get; set; }
    }
}


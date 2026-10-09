using IssueTracker.Application.DTOs;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class GetIssuesByReporterQuery : IRequest<List<IssueDto>>
    {
        public string ReporterId { get; set; }
    }
}

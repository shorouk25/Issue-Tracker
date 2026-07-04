using System.ComponentModel.DataAnnotations;
using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class SearchIssueQueryHandler : IRequestHandler<SearchIssueQuery, List<IssueDto>>
    {
        private readonly IIssueRepository _issueRepository;

        public SearchIssueQueryHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<List<IssueDto>> Handle(SearchIssueQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var existingIssues = await _issueRepository.SearchIssueByNameAsync(request.SearchTerm);

            if (existingIssues == null || !existingIssues.Any())
                return new List<IssueDto>(); //return empty list

            var issueDtos = existingIssues.Select(issue => new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                Summary = issue.Summary,
                ProjectId = issue.ProjectId,
            }).ToList();

            return issueDtos;
        }
    }
}

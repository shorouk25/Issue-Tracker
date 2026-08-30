using System;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangeCategoryCommandHandler : IRequestHandler<ChangeCategoryCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        public ChangeCategoryCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<int> Handle(ChangeCategoryCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.IssueId);
            if (issue == null)
            {
                throw new Exception($"Issue with ID {request.IssueId} not found.");
            }
            issue.Category = request.NewCategory;
            await _issueRepository.UpdateIssueAsync(issue);
            return issue.Id;
        }
    }
}
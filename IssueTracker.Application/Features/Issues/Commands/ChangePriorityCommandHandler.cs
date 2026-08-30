using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangePriorityCommandHandler: IRequestHandler<ChangePriorityCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        public ChangePriorityCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<int> Handle(ChangePriorityCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.IssueId);
            if (issue == null)
            {
                throw new Exception($"Issue with ID {request.IssueId} not found.");
            }
            issue.Priority = request.NewPriority;
            await _issueRepository.UpdateIssueAsync(issue);
            return issue.Id;
        }
    }
}
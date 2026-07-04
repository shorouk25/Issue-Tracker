using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        public ChangeStatusCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task<int> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.Id);
            if (issue == null)
            {
                throw new Exception($"Issue with ID {request.Id} not found.");
            }
            await _issueRepository.UpdateStatusAsync(issue.Id, request.Status);
            return issue.Id;
        }
    }
}

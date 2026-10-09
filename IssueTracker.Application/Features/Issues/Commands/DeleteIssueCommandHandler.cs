using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, Unit>
    {
        private readonly IIssueRepository _issueRepository;

        public DeleteIssueCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.Id);
            if (issue == null) {
                throw new Exception($"Issue with Id {request.Id} not found.");
            }
            await _issueRepository.DeleteIssueAsync(issue);
            return Unit.Value;
        }
    }
}

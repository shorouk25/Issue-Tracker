using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class AssignIssueCommandHandler: IRequestHandler<AssignIssueCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        public AssignIssueCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        
        public async Task<int> Handle(AssignIssueCommand request, CancellationToken cancellationToken)
        {
            var existingIssue = await _issueRepository.GetIssueByIdAsync(request.Id);
            if (existingIssue == null)
                throw new Exception("Issue not found");
            existingIssue.AssigneeId = request.AssigneeId;
            await _issueRepository.UpdateAssigneeAsync(existingIssue.Id, existingIssue.AssigneeId);
            return existingIssue.Id;
        }
    }
}

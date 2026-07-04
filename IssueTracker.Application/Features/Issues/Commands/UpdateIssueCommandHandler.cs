using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand>
    {
        private readonly IIssueRepository _issueRepository;
        public UpdateIssueCommandHandler(IIssueRepository issueRepository) 
        {
            _issueRepository = issueRepository;
        }

        public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var existingIssue = await _issueRepository.GetIssueByIdAsync(request.Id);
            if (existingIssue == null)
                throw new Exception("Issue not found");

            if(request.Name != null)
                existingIssue.Name = request.Name;

            if(request.Summary != null)
                existingIssue.Summary = request.Summary;

            if(request.Description != null)
                existingIssue.Description = request.Description;

            if(request.Priority.HasValue)
                existingIssue.Priority = request.Priority;

            if(request.Category.HasValue)
                existingIssue.Category = request.Category;

            if(request.AssigneeId.HasValue)
                existingIssue.AssigneeId = request.AssigneeId;

            if(request.ProjectId.HasValue)
                existingIssue.ProjectId = request.ProjectId;

            await _issueRepository.UpdateIssueAsync(existingIssue);
            return Unit.Value;
        }
    }
}

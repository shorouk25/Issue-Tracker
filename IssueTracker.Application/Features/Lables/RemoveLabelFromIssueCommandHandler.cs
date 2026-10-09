using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class RemoveLabelFromIssueCommandHandler : IRequestHandler<RemoveLabelFromIssueCommand>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ILabelRepository _labelRepository;

        public RemoveLabelFromIssueCommandHandler(IIssueRepository issueRepository, ILabelRepository labelRepository)
        {
            _issueRepository = issueRepository;
            _labelRepository = labelRepository;
        }

        public async Task<Unit> Handle(RemoveLabelFromIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetIssueByIdAsync(request.IssueId);
            if (issue == null)
            {
                throw new Exception($"Issue with ID {request.IssueId} not found.");
            }
            var label = await _labelRepository.GetLabelByIdAsync(request.LabelId);
            if (label == null)
            {
                throw new Exception($"Label with ID {request.LabelId} not found.");
            }
            var labelToRemove = issue.Labels.FirstOrDefault(l => l.Id == label.Id);
            if (labelToRemove != null)
            {
                issue.Labels.Remove(labelToRemove);
                await _issueRepository.UpdateIssueAsync(issue);
            }
            return Unit.Value;
        }
    }
}

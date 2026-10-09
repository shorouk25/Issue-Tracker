using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class AddLabelToIssueCommandHandler : IRequestHandler<AddLabelToIssueCommand>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ILabelRepository _labelRepository;
        public AddLabelToIssueCommandHandler(IIssueRepository issueRepository, ILabelRepository labelRepository)
        {
            _issueRepository = issueRepository;
            _labelRepository = labelRepository;
        }
        public async Task<Unit> Handle(AddLabelToIssueCommand request, CancellationToken cancellationToken)
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

            if(!issue.Labels.Any(l => l.Id == label.Id))
            {
                issue.Labels.Add(label);
                await _issueRepository.UpdateIssueAsync(issue);
            }
            return Unit.Value;
        }
    }
}

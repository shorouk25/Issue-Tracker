using IssueTracker.Application.Features.Labels;
using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class CreateLabelCommandHandler : IRequestHandler<CreateLabelCommand, int>
    {
        private readonly ILabelRepository _labelRepository;
        public CreateLabelCommandHandler(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<int> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var label = new Label
            {
                Name = request.Name,
            };
            await _labelRepository.AddLabelAsync(label);
            return label.Id;
        }
    }
}
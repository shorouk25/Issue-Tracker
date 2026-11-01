using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Application.Interfaces;
using MediatR;

namespace IssueTracker.Application.Features.Lables
{
    public class DeleteLabelCommandHandler : IRequestHandler<DeleteLabelCommand>
    {
        private readonly ILabelRepository _labelRepository;
        public DeleteLabelCommandHandler(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<Unit> Handle(DeleteLabelCommand request, CancellationToken cancellationToken)
        {
            var label = await _labelRepository.GetLabelByIdAsync(request.Id);
            if (label == null)
            {
                throw new Exception($"Label with ID {request.Id} not found.");
            }
            await _labelRepository.DeleteLabelAsync(label.Id);
            return Unit.Value;
        }
    }
}
//delete everything related to the label,
//including the label itself and any references to it in issues
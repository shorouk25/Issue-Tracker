using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await _issueRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}

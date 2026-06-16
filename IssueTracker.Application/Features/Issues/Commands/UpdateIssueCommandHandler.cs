using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                existingIssue.Priority = request.Priority.Value;

            if(request.Category.HasValue)
                existingIssue.Category = request.Category.Value;

            if(request.AssigneId.HasValue)
                existingIssue.AssigneId = request.AssigneId.Value;

            if(request.ProjectId.HasValue)
                existingIssue.ProjectId = request.ProjectId.Value;

            await _issueRepository.UpdateAsync(existingIssue);
            return Unit.Value;
        }
    }
}

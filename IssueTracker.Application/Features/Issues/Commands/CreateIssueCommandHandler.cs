using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, int>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IProjectRepository _projectRepository;

        public CreateIssueCommandHandler(IIssueRepository issueRepository, IProjectRepository projectRepository)
        {
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(request.ProjectId);
            if (project == null)
                throw new Exception("Project not found");

            var newIssue = new Issue
            {
                Name = request.Name,
                Summary = request.Summary,
                Description = request.Description,
                Status = Status.Open,
                Priority = request.Priority,
                Category = request.Category,
                Assignee = request.Assignee,
                ProjectId = request.ProjectId,
            };

            await _issueRepository.AddAsync(newIssue);
            return newIssue.Id;
        }
    }
}

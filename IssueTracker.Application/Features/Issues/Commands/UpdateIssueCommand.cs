using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class UpdateIssueCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public Category? Category { get; set; }
        public int? AssigneId { get; set; }
        public int? ProjectId { get; set; }
    }
}

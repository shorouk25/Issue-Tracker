using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class DeleteIssueCommand : IRequest
    {
        public int Id { get; set; }
    }
}

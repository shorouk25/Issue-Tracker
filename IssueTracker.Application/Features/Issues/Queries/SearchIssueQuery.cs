using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using IssueTracker.Application.DTOs;
using IssueTracker.Application.Interfaces;

namespace IssueTracker.Application.Features.Issues.Queries
{
    public class SearchIssueQuery : IRequest<List<IssueDto>>
    {
        public string SearchTerm { get; set; }
    }
}


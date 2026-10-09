using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.DTOs
{//it displays the issue details in a simplified way in the UI
    public class IssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ReporterId { get; set; }
        public string ReporterName { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}

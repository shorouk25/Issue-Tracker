using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Domain.Enums;

namespace IssueTracker.Domain.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Department? Department { get; set; }
        public Company? Company { get; set; }
        public Role Role { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Issue> ReportedIssues { get; set; } = new List<Issue>();
        public List<Issue> AssignedIssues { get; set; } = new List<Issue>();
    }
}

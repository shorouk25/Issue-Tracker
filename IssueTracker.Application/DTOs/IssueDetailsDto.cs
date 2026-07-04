using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Domain.Enums;
using IssueTracker.Domain.Models;

namespace IssueTracker.Application.DTOs
{
    public class IssueDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public int? AssigneeId { get; set; }
        public int? ProjectId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Label> Labels { get; set; }
    }
}

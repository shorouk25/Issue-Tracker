using IssueTracker.Domain.Enums;

namespace IssueTracker.Domain.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public Status Status { get; set; }
        public Priority? Priority { get; set; }
        public Category? Category { get; set; }
        public User Reporter { get; set; }
        public int? AssigneeId { get; set; }
        public User? Assignee { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        public List<Label> Labels { get; set; } = new List<Label>();
    }
}

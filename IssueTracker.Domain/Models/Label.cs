namespace IssueTracker.Domain.Models
{
    public class Label
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}

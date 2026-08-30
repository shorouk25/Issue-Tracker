namespace IssueTracker.Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}

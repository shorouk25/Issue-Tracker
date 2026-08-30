using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

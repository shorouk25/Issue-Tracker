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
        public User Author { get; set; }
        public Issue Issue { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

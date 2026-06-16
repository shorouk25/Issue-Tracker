using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}

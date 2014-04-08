using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitService.Models
{
    class CommitSummary
    {
        public string url { get; set; }
        public UserSummary author { get; set; }
        public UserSummary committer { get; set; }
        public string message { get; set; }
        public Tree tree { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitService.Models
{
    class Commit
    {
        public string url { get; set; }
        public string sha { get; set; }
        public CommitSummary commit { get; set; }
        public User author { get; set; }
        public User committer { get; set; }
        public List<Tree> parents { get; set; }
        public Stats stats { get; set; }
        public List<File> files { get; set; }
    }
}

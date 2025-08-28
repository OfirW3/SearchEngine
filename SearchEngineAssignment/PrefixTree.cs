using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    public class PrefixTree
    {
        public Dictionary<char, PrefixTree> Children;
        public HashSet<int> Indexes { get; private set; }

        public PrefixTree()
        {
            this.Children = new Dictionary<char, PrefixTree>();
            this.Indexes = new HashSet<int>();
        }
    }
}

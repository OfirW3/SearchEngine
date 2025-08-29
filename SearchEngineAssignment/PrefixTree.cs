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

        public bool IsEndOfWord { get; set; }

        public PrefixTree()
        {
            this.Children = new Dictionary<char, PrefixTree>();
            this.Indexes = new HashSet<int>();
            this.IsEndOfWord = IsEndOfWord;
        }

        public HashSet<int> GetIndexesByPrefix(string prefix)
        {
            PrefixTree tail = this;
            HashSet<int> indexes = new HashSet<int>();
            foreach (char c in prefix)
            {
                if (!tail.Children.ContainsKey(c))
                {
                    return new HashSet<int>();
                }
                tail = tail.Children[c];
            }
            CollectAllIndexes(tail, indexes);
            return indexes;
        }

        private void CollectAllIndexes(PrefixTree subTree, HashSet<int> result)
        {
            if (subTree.IsEndOfWord)
            {
                result.UnionWith(subTree.Indexes);
            }
            else {
                foreach(var child in subTree.Children)
                {
                    CollectAllIndexes(child.Value,result);
                }
            }
        }
    }
}

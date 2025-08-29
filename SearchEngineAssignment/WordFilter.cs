using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class WordFilter : SearchFilter
    {
        public string Word { get; private set; }

        public WordFilter(string word)
        {
            this.Word = word;
        }

        public override void ProcessFilter(SearchEngine engine,HashSet<int> result)
        {
            result.UnionWith(engine.GetMatchingIndexes(this.Word));
        }
    }
}

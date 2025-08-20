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
        public string word { get; private set; }

        public WordFilter(string word)
        {
            this.word = word;
        }

        public override HashSet<int> MatchingIndexs(SearchEngine engine)
        {
            return engine.GetMatchesIndexes(this.word);
        }
    }
}

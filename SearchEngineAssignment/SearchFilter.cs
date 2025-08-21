using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal abstract class SearchFilter
    {
        public abstract void ProcessFilter(SearchEngine engine,HashSet<int> result);
    }
}

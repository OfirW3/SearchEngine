using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class OrOperator : SearchFilter
    {
        public SearchFilter left { get; set; } //HashSet<int>
        public SearchFilter right { get; set; } //HashSet<int>

        public OrOperator(SearchFilter left, SearchFilter right)
        {
            this.left = left;
            this.right = right;
        }

        public override void ProcessFilter(SearchEngine engine,HashSet<int> result)
        {
            left.ProcessFilter(engine, result); //Get the indexes from the left filter
            right.ProcessFilter(engine, result); //Get the indexes from the right filter
        }
    }
}

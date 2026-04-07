using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class AndOperator : SearchFilter
    {
        public SearchFilter left { get; set; } //HashSet<int>
        public SearchFilter right { get; set; } //HashSet<int>
        public AndOperator(SearchFilter left, SearchFilter right)
        {
            this.left = left;
            this.right = right;
        }

        public override void ProcessFilter(SearchEngine engine, HashSet<int> result)
        {
            HashSet<int> leftIndexes = new HashSet<int>();
            HashSet<int> rightIndexes = new HashSet<int>();
            left.ProcessFilter(engine, leftIndexes); //Get the indexes from the left filter
            right.ProcessFilter(engine, rightIndexes); //Get the indexes from the right filter
            //Intersect the two sets to get the common indexes
            leftIndexes.IntersectWith(rightIndexes);
            result.UnionWith(leftIndexes); //Returnes the intersection of left and right indexes - implmenting the AND operator
        }

    }
}

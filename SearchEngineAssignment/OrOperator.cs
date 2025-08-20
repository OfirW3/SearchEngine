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

        public override HashSet<int> MatchingIndexs(SearchEngine engine)
        {
            HashSet<int> leftIndexes = left.MatchingIndexs(engine);
            HashSet<int> rightIndexes = right.MatchingIndexs(engine);
            leftIndexes.UnionWith(rightIndexes);//Returnes the union of left and right indexes - implmenting the OR operator
            return leftIndexes;
        }
    }
}

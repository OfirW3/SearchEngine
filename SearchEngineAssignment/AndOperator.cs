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

        public override HashSet<int> MatchingIndexs(SearchEngine engine)
        {
            HashSet<int> leftIndexes = left.MatchingIndexs(engine);
            HashSet<int> rightIndexes = right.MatchingIndexs(engine);
            leftIndexes.IntersectWith(rightIndexes);
            return leftIndexes; //Returnes the intercetion between the left indexes and the right indexes - AND operator
        }

    }
}

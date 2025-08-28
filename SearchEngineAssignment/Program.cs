using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dataset = new string[]
            {
               "Today is Sunday",
               "Today is not Monday",
               "Tomorrow is Tuesday",
               "Tomorrow isn’t Wednesday"
            };
            SearchFilter leftBranch = new AndOperator(
            new WordFilter("Today"),
            new WordFilter("Sunday")
            );

            // Build the right side of the OR operator: ( ( “not” || “Tomorrow” ) && “is” )
            SearchFilter rightBranch = new AndOperator(
                new OrOperator(
                    new WordFilter("not"),
                    new WordFilter("Tomorrow")
                ),
                new WordFilter("is")
            );

            // Combine the two main branches with an OR operator.
            SearchFilter fullFilter = new OrOperator(leftBranch, rightBranch);
            
            SearchEngine engine = new SearchEngine(dataset);
            string[] result  = engine.Search(fullFilter);
            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}

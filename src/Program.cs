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
               "Tomorrow isn’t Wednesday",
               "Today is Sunday"
            };
            SearchFilter leftBranch = new AndOperator(
            new WordFilter("Tod"),
            new WordFilter("Sun")
            );

            
            
            SearchEngine engine = new SearchEngine(dataset);
            string[] result  = engine.Search(leftBranch);
            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}

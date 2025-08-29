using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class SearchEngine
    {
        private string[] dataset;
        private PrefixTree indexTree;
        public SearchEngine(string[] dataset)
        {
            this.dataset = dataset;
            this.indexTree = new PrefixTree(false);
            DatasetIndex();
        }

        private void DatasetIndex() //Indexing the dataset for faster searching. Complexity is O(Number of words in dataset).
        {
            for (int i = 0; i < dataset.Length; i++) //Speed: O(number of letters in the dataset)
            {
                string[] words = dataset[i].ToLower().Split(' ');
                foreach (string word in words)
                {
                    PrefixTree tail = this.indexTree;
                    foreach (char c in word)
                    {
                        if (!tail.Children.ContainsKey(c))
                        {
                            tail.Children[c] = new PrefixTree(false);
                        }
                        tail = tail.Children[c];
                    }
                    tail.Indexes.Add(i); 
                    tail.IsEndOfWord = true;
                }
            }
        }

        public HashSet<int> GetMatchesIndexes(string prefix)
        {
            prefix = prefix.ToLower();
            return this.indexTree.GetIndexesByPrefix(prefix);
        }

        public string[] Search(SearchFilter filter)
        {
            HashSet<int> filteredIndexes = new HashSet<int>();
            filter.ProcessFilter(this, filteredIndexes); //Process the filter to get the matching indexes according to the filter and the dataset
            if (filteredIndexes.Count == 0)
            {
                return new string[0]; //If no matches found, return an empty array
            }
            HashSet<string> unique = new HashSet<string>();
            List<string> result = new List<string>();
            foreach (int index in filteredIndexes)
            {
                if (unique.Add(dataset[index]))
                {
                    result.Add(dataset[index]);
                }
            }
            return result.ToArray();
        }
    }
}

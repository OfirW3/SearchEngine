using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineAssignment
{
    internal class SearchEngine
    {
        private string[] dataset;
        public Dictionary<string, HashSet<int>> index; //* This it the best data stracture for indexing the dataset efficentlly
        public SearchEngine(string[] dataset)
        {
            this.dataset = dataset;
            DatasetIndex();
        }

        private void DatasetIndex()
        {
            for (int i = 0; i < dataset.Length; i++) //Indexing every word in the dataset - the most efficent way is to read every word and index it
            {
                string[] words = dataset[i].ToLower().Split(' ');
                foreach(string word in words)
                {
                    if (!this.index.ContainsKey(word))
                    {
                        HashSet<int> set = new HashSet<int>();
                        this.index[word] = set;
                    }
                    this.index[word].Add(i);
                }
            }
        }
        
        public HashSet<int> GetMatchesIndexes(string word)
        {
            word = word.ToLower();
            if (index.ContainsKey(word))
            {
                return new HashSet<int>(index[word]);//Creating a copy in order to not corrupt the original index HashSet
            }
            return new HashSet<int>();
        }

        public string[] Search(SearchFilter filter)
        {
            HashSet<int> indexes = filter.MatchingIndexs(this);
            string[] result = new string[index.Count];
            int count = 0;
            foreach(int index in  indexes)
            {
                result[count] = dataset[index];
                count++;
            }
            return result;
        }
    }
}

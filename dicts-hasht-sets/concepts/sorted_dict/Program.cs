using System;
using System.Collections.Generic;

namespace sorted_dict
{
    class Program
    {
        private static readonly string Text = "Mary had a little lamb, little Lamb, little Lamb, Mary had a Little lamb, whose fleexe were white as snow";
        static void Main(string[] args)
        {
            SortedDictionary<string, int> wordOccurenceMap = GetWordOccurrenceMap(Text);

        }
        private static SortedDictionary<string, int> GetWordOccurrenceMap(string text)
        {
            string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');
            SortedDictionary<string, int> words = new SortedDictionary<string, int>();
            foreach(var word in tokens)
            {
                if(!string.IsNullOrEmpty(word.Trim()))
                {
                    int count;
                    if(!words.TryGetValue(word,out count))
                }
            }
        }
    }
}

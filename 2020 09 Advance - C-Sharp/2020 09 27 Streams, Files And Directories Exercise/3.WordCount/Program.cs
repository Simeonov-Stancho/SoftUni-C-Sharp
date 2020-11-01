using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            string[] text = File.ReadAllLines("../../../text.txt");

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 0);
                }
            }

            foreach (var line in text)
            {
                string[] lines = line.ToLower().Split(new char[] { ' ', '-', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in lines)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                }
            }

            foreach (var kpv in wordCount)
            {
                File.AppendAllText(@"..\..\..\actualResult.txt", $"{kpv.Key} - {kpv.Value}{Environment.NewLine}");
            }

            wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, v => v.Value);

            foreach (var kpv in wordCount)
            {
                File.AppendAllText(@"..\..\..\expectedResult.txt", $"{kpv.Key} - {kpv.Value}{Environment.NewLine}");
            }
        }
    }
}
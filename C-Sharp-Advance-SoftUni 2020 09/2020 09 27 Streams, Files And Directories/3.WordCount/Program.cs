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
            string words = File.ReadAllText(@"..\..\..\words.txt");
            string[] wordInWords = words.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] input = File.ReadAllLines(@"..\..\..\input.txt");

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in wordInWords)
            {
                if (!wordCount.ContainsKey(word.ToLower()))
                {
                    wordCount.Add(word, 0);
                }
            }

            
            foreach (var currentline in input)
            {
                string[] line = currentline.ToLower().Split(new char[] { ' ', '-', ',', '.', '?', '!' });

                foreach (var word in line)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                }
            }

            wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x=>x.Key, v=>v.Value);

            foreach (var kpv in wordCount)
            {
                File.AppendAllText(@"..\..\..\output.txt", $"{kpv.Key} - {kpv.Value}{Environment.NewLine}");
            }
        }
    }
}

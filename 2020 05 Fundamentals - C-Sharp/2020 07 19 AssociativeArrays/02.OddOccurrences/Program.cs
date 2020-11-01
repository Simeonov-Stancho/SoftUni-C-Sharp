using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> word = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {
                string wordToLower = text[i].ToLower();
                if (word.ContainsKey(wordToLower))
                {
                    word[wordToLower]++;
                }

                else
                {
                    word.Add(wordToLower, 1);
                }
            }

            foreach (var pair in word)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.Write(pair.Key + " ");
                }
            }
        }
    }
}

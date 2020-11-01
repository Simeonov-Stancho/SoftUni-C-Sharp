using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheFinalQuestGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands[0] == "Delete")
                {
                    int index = int.Parse(commands[1]) + 1;

                    if (index >= 0 && index < words.Count)
                    {
                        words.RemoveAt(index);
                    }
                }

                else if (commands[0] == "Swap")
                {
                    string word1 = commands[1];
                    string word2 = commands[2];

                    if (words.Contains(word1) && words.Contains(word2))
                    {
                        int index1 = words.IndexOf(word1);
                        int index2 = words.IndexOf(word2);

                        words[index1] = word2;
                        words[index2] = word1;
                    }
                }

                else if (commands[0] == "Put")
                {
                    string word = commands[1];
                    int index = int.Parse(commands[2]);

                    if (index - 1 >= 0 && index - 1 <= words.Count)
                    {
                        words.Insert(index - 1, word);
                    }
                }

                else if (commands[0] == "Sort")
                {
                    words.Sort();
                    words.Reverse();
                }

                else if (commands[0] == "Replace")
                {
                    string word1 = commands[1];
                    string word2 = commands[2];

                    if (words.Contains(word2))
                    {
                        int index = words.IndexOf(word2);

                        words[index] = word1;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', words));
        }
    }
}

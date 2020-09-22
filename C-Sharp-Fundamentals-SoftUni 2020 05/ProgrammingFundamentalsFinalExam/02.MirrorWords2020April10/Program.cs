using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords2020April10
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> mirrorWords = new List<string>();

            string pattern = @"(@|#)(?<wordOne>[A-Za-z]{3,})(\1)(\1)(?<wordTwo>[A-Za-z]{3,})(\1)";
            Regex regex = new Regex(pattern);

            MatchCollection pairs = regex.Matches(input);

            if (pairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }

            else if (pairs.Count != 0)
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }

            foreach (Match pair in pairs)
            {
                if (pair.Success)
                {
                    string wordOne = pair.Groups["wordOne"].Value;
                    string wordTwo = pair.Groups["wordTwo"].Value;

                    char[] charWordTwo = wordTwo.ToCharArray();
                    Array.Reverse(charWordTwo);
                    string wordTwoReversed = new String(charWordTwo);

                    if (wordOne == wordTwoReversed)
                    {
                        string pairPrint = wordOne + " <=> " + wordTwo;
                        mirrorWords.Add(pairPrint);
                    }
                }

            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }

            else if (mirrorWords.Count != 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
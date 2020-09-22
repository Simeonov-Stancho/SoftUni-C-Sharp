using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._2020April04EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([:*])\1(?<emoji>[A-Z][a-z]{2,})\1\1";
            Regex regex = new Regex(pattern);

            MatchCollection emojis = regex.Matches(text);

            BigInteger coolThresholdSum = 1;
            List<string> coolEmojis = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    coolThresholdSum *= (text[i] - 48);
                }
            }

            foreach (Match emoji in emojis)
            {
                string currentEmoji = emoji.Groups["emoji"].Value;
                BigInteger threshold = 0;

                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    threshold += currentEmoji[i];
                }

                if (threshold > coolThresholdSum)
                {
                    coolEmojis.Add(emoji.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
        }
    }
}

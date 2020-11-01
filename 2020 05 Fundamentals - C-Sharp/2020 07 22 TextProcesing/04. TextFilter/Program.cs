using System;
using System.Linq;

namespace _04._TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string text = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                string replacmentWord = string.Empty;
                while (text.Contains(bannedWords[i]))
                {
                    for (int j = 0; j < bannedWords[i].Length; j++)
                    {
                        replacmentWord += '*';
                    }

                    text = text.Replace(bannedWords[i], replacmentWord);
                }
            }

            Console.WriteLine(text);
        }
    }
}

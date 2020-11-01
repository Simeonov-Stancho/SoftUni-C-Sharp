using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] evenWordsLength = words
                .Where(length => length.Length % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, evenWordsLength));
        }
    }
}

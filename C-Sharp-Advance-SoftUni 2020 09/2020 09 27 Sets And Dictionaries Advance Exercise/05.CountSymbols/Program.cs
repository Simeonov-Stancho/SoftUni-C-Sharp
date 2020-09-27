using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            foreach (char currentChar in input)
            {
                if (!symbols.ContainsKey(currentChar))
                {
                    symbols.Add(currentChar, 0);
                }

                symbols[currentChar]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
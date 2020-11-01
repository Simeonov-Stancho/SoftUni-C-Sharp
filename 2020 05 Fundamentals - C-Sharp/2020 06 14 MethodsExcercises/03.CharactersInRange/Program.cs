using System;
using System.Transactions;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintCharactersInRange(char.Parse(Console.ReadLine()),
                                   char.Parse(Console.ReadLine()));
        }

        static void PrintCharactersInRange(char startChar, char endChar)
        {
            char currentChar = startChar;
            for (int i = startChar; i < endChar - 1; i++)
            {
                Console.Write($"{(char)(i + 1)} ");
            }

            for (int i = endChar; i < startChar-1; i++)
            {
                Console.Write($"{(char)(i + 1)} ");
            }
        }
    }
}

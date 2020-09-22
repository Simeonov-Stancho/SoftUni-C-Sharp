using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] symbol = text.Split();

            //for (int i = symbol.Length - 1; i >= 0; i--)
            //{
            //    Console.Write($"{symbol[i]} ");
            //}

            for (int i = 0; i < symbol.Length / 2; i++)
            {
                string reversed = symbol[i];
                symbol[i] = symbol[symbol.Length - i - 1];
                symbol[symbol.Length - i - 1] = reversed;
            }

            Console.WriteLine(string.Join(" ", symbol));
        }
    }
}
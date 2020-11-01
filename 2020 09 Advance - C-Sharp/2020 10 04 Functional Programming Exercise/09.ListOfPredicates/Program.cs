using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> func = (x, y) => x % y != 0;
            List<int> dividedNumbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivide = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (func(i, dividers[j]))
                    {
                        isDivide = false;
                        break;
                    }
                }

                if (isDivide)
                {
                    dividedNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", dividedNumbers));
        }
    }
}

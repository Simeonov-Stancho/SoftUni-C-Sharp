using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> orderNumbers = numbers.OrderByDescending(x => x).ToList();
            int count = 0;

            for (int i = 0; i < orderNumbers.Count; i++)
            {
                Console.Write(orderNumbers[i] + " ");
                count++;
                if (count == 3)
                {
                    break;
                }
            }
        }
    }
}

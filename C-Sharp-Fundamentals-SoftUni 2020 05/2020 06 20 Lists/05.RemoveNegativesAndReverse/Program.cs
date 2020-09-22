using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadList();

            if (RemoveNegative(numbers).Count == 0)
            {
                Console.WriteLine("empty");
            }

            else
            {
                Console.WriteLine(string.Join(" ", RemoveNegative(numbers)));
            }
        }

        static List<int> ReadList()
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            return numbers;
        }

        static List<int> RemoveNegative(List<int> numbers)
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    continue;
                }

                else
                {
                    newList.Add(numbers[i]);
                }
            }
            newList.Reverse();
            return newList;
        }
    }
}

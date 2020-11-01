using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = ReadList();
            Console.WriteLine(string.Join(" ", SumListEqualElements(numbers)));
        }

        static List<double> ReadList()
        {
            List<double> input = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToList();
            return input;
        }

        static List<double> SumListEqualElements(List<double> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == (numbers[i + 1]))
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }

            return numbers;
        }
    }
}
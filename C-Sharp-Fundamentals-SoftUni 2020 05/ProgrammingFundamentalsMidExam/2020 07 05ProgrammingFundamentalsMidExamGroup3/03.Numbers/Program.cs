using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double averageValue = CaclulateAverageValueOfList(numbers);

            List<int> topFive = new List<int>();
            topFive = FindTopFiveInList(numbers, averageValue);
            PrintResult(topFive);
        }

        static double CaclulateAverageValueOfList(List<int> numbers)
        {
            int sumListNumbers = numbers.Sum();
            double averageValue = sumListNumbers * 1.0 / numbers.Count;

            return averageValue;
        }

        static List<int> FindTopFiveInList(List<int> numbers, double averageValue)
        {
            List<int> topFive = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                int maxValue = int.MinValue;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] >= maxValue && numbers[j] > averageValue)
                    {
                        maxValue = numbers[j];
                    }
                }

                if (maxValue > int.MinValue)
                {
                    topFive.Insert(i, maxValue);
                    numbers.Remove(maxValue);
                }
            }

            return topFive;
        }

        static void PrintResult(List<int> topFive)
        {
            if (topFive.Count == 0)
            {
                Console.WriteLine("No");
            }

            else
            {
                Console.WriteLine(string.Join(" ", topFive));
            }
        }
    }
}
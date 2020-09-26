using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            int count = 1;
            Dictionary<double, int> countTimes = new Dictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                double currentNum = array[i];

                if (!countTimes.ContainsKey(currentNum))
                {
                    countTimes.Add(currentNum, count);
                }

                else
                {
                    countTimes[currentNum]++;
                }
            }

            foreach (var pair in countTimes)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}

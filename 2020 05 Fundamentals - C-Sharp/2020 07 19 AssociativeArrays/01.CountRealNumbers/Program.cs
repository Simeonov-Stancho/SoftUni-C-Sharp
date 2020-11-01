using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020_07_19AssociativeArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> num = new SortedDictionary<double, int>();
            foreach (double number in numbers)
            {
                if (num.ContainsKey(number))
                {
                    num[number]++;
                }

                else
                {
                    num.Add(number, 1);
                }
            }

            foreach (var pair in num)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }



        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            int sum = 0;
            int currentNum = -1;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int element = numbers[numbers.Count - 1];
                    sum += numbers[0];
                    currentNum = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, element);
                }

                if (index > numbers.Count - 1)
                {
                    int element = numbers[0];
                    sum += numbers[numbers.Count - 1];
                    currentNum = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(element);
                }

                if (index >= 0 && index < numbers.Count)
                {
                    currentNum = numbers[index];
                    sum += numbers[index];
                    numbers.RemoveAt(index);
                }

                ManipulateNumbers(numbers, currentNum);
            }

            Console.WriteLine($"{sum}");
        }

        static List<int> ManipulateNumbers(List<int> numbers, int currentNum)
        {
            for (int i = 0; i < numbers.Count; i++)
            {

                if (numbers[i] <= currentNum)
                {
                    numbers[i] += currentNum;
                }

                else
                {
                    numbers[i] -= currentNum;
                }
            }

            return numbers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bombField = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            List<int> input = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            int specialBombNumber = input[0];
            int power = input[1];

            while (bombField.Contains(specialBombNumber))
            {
                int index = bombField.IndexOf(specialBombNumber);

                int startIndex = index - power;
                int endIndex = index + power;

                while (startIndex < 0)
                {
                    startIndex += 1;
                }

                while (endIndex > (bombField.Count - 1))
                {
                    endIndex -= 1;
                }

                bombField.RemoveRange((startIndex), (endIndex - startIndex + 1));
            }

            int sum = bombField.Sum();
            Console.WriteLine($"{sum}");
        }
    }
}

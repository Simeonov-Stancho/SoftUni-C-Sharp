using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Action<int[]> print = arr =>
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    };

                    print(numbers);
                }

                else
                {
                    Func<int[], int[]> arithmetics = AppliedArithmetics(command);
                    numbers = arithmetics(numbers);
                }
            }
        }

        static Func<int[], int[]> AppliedArithmetics(string command)
        {
            Func<int[], int[]> arithmetics = null;

            if (command == "add")
            {
                arithmetics = new Func<int[], int[]>(num =>
                {
                    return num.Select(n => n += 1)
                                  .ToArray();
                });
            }

            else if (command == "multiply")
            {
                arithmetics = new Func<int[], int[]>(num =>
                {
                    return num.Select(x => x *= 2)
                                  .ToArray();
                });
            }

            else if (command == "subtract")
            {
                arithmetics = new Func<int[], int[]>(num =>
                {
                    return num.Select(x => x -= 1)
                                  .ToArray();
                });
            }

            return arithmetics;
        }
    }
}
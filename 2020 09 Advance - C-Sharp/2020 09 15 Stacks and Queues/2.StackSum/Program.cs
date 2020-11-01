using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> integerStack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                integerStack.Push(numbers[i]);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                List<string> currentCommand = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = currentCommand[0];

                if (command == "add")
                {
                    integerStack.Push(int.Parse(currentCommand[1]));
                    integerStack.Push(int.Parse(currentCommand[2]));
                }

                else if (command == "remove")
                {
                    int count = int.Parse(currentCommand[1]);
                    if (count > integerStack.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        integerStack.Pop();
                    }
                }
            }

            int sum = integerStack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

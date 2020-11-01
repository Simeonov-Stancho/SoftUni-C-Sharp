using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (array[0] == 1)
                {
                    stack.Push(array[1]);
                }

                if (stack.Count > 0)
                {
                    if (array[0] == 2)
                    {
                        stack.Pop();
                    }

                    else if (array[0] == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }

                    else if (array[0] == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

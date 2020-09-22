using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(array);

            while (queue.Count > 1)
            {
                PrintEven(queue);
                RemoveUnEven(queue);
            }

            if (queue.Peek() % 2 == 0)
            {
                Console.WriteLine($"{queue.Dequeue()}");
            }

        }

        static void PrintEven(Queue<int> queue)
        {
            if (queue.Peek() % 2 == 0)
            {
                Console.Write($"{queue.Dequeue()}, ");
            }
        }

        static void RemoveUnEven(Queue<int> queue)
        {
            if (queue.Peek() % 2 != 0)
            {
                queue.Dequeue();
            }
        }
    }
}

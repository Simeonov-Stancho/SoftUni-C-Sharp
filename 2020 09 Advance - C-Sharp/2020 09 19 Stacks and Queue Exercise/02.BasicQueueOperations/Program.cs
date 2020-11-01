using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberAddElement = input[0];
            int numberRemoveElement = input[1];
            int xElement = input[2];

            int[] numbers = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numberRemoveElement; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            else if (queue.Contains(xElement))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}

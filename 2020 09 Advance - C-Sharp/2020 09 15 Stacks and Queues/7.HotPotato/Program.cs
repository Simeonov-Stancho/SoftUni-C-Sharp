using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int toss = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(players);

            while (queue.Count > 1)
            {
                for (int i = 1; i <= toss; i++)
                {
                    if (i == toss)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }

                    else
                    {
                        string player = queue.Dequeue();
                        queue.Enqueue(player);

                    }
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.StartsWith('A'))
                {
                    string song = command.Remove(0, 4);

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }

                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }

                else if (command == "Play")
                {
                    queue.Dequeue();
                }

                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}

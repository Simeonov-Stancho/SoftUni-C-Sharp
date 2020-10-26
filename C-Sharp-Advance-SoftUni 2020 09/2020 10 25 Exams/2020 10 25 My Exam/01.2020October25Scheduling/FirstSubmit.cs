using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskValue = int.Parse(Console.ReadLine());
            Stack<int> tasks = new Stack<int>(tasksArray);
            Queue<int> threads = new Queue<int>(threadsArray);

            while (taskValue != tasks.Peek() || threads.Count == 0)
            {
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }

                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskValue}");

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
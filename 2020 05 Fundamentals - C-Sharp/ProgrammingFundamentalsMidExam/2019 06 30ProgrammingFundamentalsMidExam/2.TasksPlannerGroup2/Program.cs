using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2.TasksPlannerGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                if (commands[0] == "Complete")
                {
                    CompleteTask(tasks, commands);
                }

                else if (commands[0] == "Change")
                {
                    ChangeTime(tasks, commands);
                }

                else if (commands[0] == "Drop")
                {
                    DropTime(tasks, commands);
                }

                else if (commands[1] == "Completed")
                {
                    Console.WriteLine(CheckCompleted(tasks, commands));
                }

                else if (commands[1] == "Incomplete")
                {
                    Console.WriteLine(CheckInCompleted(tasks, commands));
                }

                else if (commands[1] == "Dropped")
                {
                    Console.WriteLine(CheckDropped(tasks, commands));
                }
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] > 0)
                {
                    Console.Write($"{tasks[i]} ");
                }
            }
        }

        static int[] CompleteTask(int[] tasks, string[] commands)
        {
            int index = int.Parse(commands[1]);

            if (index >= 0 && index < tasks.Length)
            {
                tasks[index] = 0;
            }
            return tasks;
        }

        static int[] ChangeTime(int[] tasks, string[] commands)
        {
            int index = int.Parse(commands[1]);
            int time = int.Parse(commands[2]);

            if (index >= 0 && index < tasks.Length)
            {
                tasks[index] = time;
            }
            return tasks;
        }

        static int[] DropTime(int[] tasks, string[] commands)
        {
            int index = int.Parse(commands[1]);

            if (index >= 0 && index < tasks.Length)
            {
                tasks[index] = -1;
            }
            return tasks;
        }

        static int CheckCompleted(int[] tasks, string[] commands)
        {
            int count = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] == 0)
                {
                    count++;
                }
            }

            return count;
        }

        static int CheckInCompleted(int[] tasks, string[] commands)
        {
            int count = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] > 0)
                {
                    count++;
                }
            }

            return count;
        }

        static int CheckDropped(int[] tasks, string[] commands)
        {
            int count = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                List<string> currentCommand = command
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (currentCommand[0] == "Shoot")
                {
                    int index = int.Parse(currentCommand[1]);
                    int power = int.Parse(currentCommand[2]);

                    if (index < 0 || index >= targets.Count)
                    {
                        continue;
                    }

                    else
                    {
                        if (targets[index] > power)
                        {
                            targets[index] -= power;
                        }

                        else
                        {
                            targets.RemoveAt(index);
                        }
                    }

                }

                else if (currentCommand[0] == "Add")
                {
                    int index = int.Parse(currentCommand[1]);
                    int value = int.Parse(currentCommand[2]);

                    if (index < 0 || index >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }

                    targets.Insert(index, value);
                }

                else if (currentCommand[0] == "Strike")
                {
                    int index = int.Parse(currentCommand[1]);
                    int radius = int.Parse(currentCommand[2]);

                    if ((index - radius) < 0 || (index + radius) >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }

                    targets.RemoveRange((index - radius), ((radius * 2) + 1));
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
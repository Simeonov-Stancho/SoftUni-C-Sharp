using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commandList = command
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .ToList();
                if (commandList[0] == "Add")
                {
                    wagons.Add(int.Parse(commandList[1]));
                }

                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(commandList[0]) <= maxCapacity)
                        {
                            wagons[i] += int.Parse(commandList[0]);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}

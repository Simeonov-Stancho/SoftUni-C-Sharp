using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2020.August09WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                List<string> command = input.Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "Add Stop")
                {
                    int index = int.Parse(command[1]);
                    string newStop = command[2];

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, newStop);
                    }

                    Console.WriteLine(stops);
                }

                else if (command[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIindex = int.Parse(command[2]);
                    int count = endIindex - startIndex + 1;

                    if ((startIndex >= 0 && startIndex < stops.Length)
                        && (endIindex >= startIndex && endIindex < stops.Length))
                    {
                        stops = stops.Remove(startIndex, count);
                    }

                    Console.WriteLine(stops);
                }

                else if (command[0] == "Switch")
                {
                    string oldString = command[1];
                    string newString = command[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }

                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
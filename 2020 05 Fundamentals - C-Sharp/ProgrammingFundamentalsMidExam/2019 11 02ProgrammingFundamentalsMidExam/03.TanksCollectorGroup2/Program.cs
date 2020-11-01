using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TanksCollectorGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                List<string> command = input
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[0] == "Add")
                {
                    string tankName = command[1];

                    if (tanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }

                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tanks.Add(tankName);
                    }
                }

                else if (command[0] == "Remove")
                {
                    string tankName = command[1];

                    if (tanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank successfully sold");
                        tanks.Remove(tankName);
                    }

                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }

                else if (command[0] == "Remove At")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index > tanks.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("Tank successfully sold");
                        tanks.RemoveAt(index);
                    }
                }

                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string tankName = command[2];

                    if (index < 0 || index > tanks.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                        continue;
                    }

                    else if (tanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }

                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        tanks.Insert(index, tankName);
                    }
                }

            }

            Console.WriteLine(string.Join(", ", tanks));
        }
    }
}

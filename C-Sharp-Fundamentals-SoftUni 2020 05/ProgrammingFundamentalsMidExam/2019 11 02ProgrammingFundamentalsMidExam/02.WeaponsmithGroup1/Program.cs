using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.WeaponsmithGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameParts = Console.ReadLine()
                            .Split('|', StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                List<string> command = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[1] == "Left")
                {
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < nameParts.Count)
                    {
                        int newIndex = index - 1;
                        string currentPart = nameParts[index];

                        if (newIndex >= 0 && newIndex < nameParts.Count)
                        {
                            nameParts.RemoveAt(index);
                            nameParts.Insert(newIndex, currentPart);
                        }
                    }
                }

                else if (command[1] == "Right")
                {
                    int index = int.Parse(command[2]);

                    if (index >= 0 && index < nameParts.Count)
                    {
                        int newIndex = index + 1;
                        string currentPart = nameParts[index];

                        if (newIndex >= 0 && newIndex < nameParts.Count)
                        {
                            nameParts.RemoveAt(index);
                            nameParts.Insert(newIndex, currentPart);
                        }
                    }
                }

                else if (command[1] == "Even")
                {
                    List<string> evenParts = new List<string>();
                    int count = 0;

                    for (int i = 0; i < nameParts.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            evenParts.Insert(count, nameParts[i]);
                            count++;
                        }
                    }

                    Console.WriteLine(string.Join(" ", evenParts));
                }

                else if (command[1] == "Odd")
                {
                    List<string> oddParts = new List<string>();
                    int count = 0;

                    for (int i = 0; i < nameParts.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            oddParts.Insert(count, nameParts[i]);
                            count++;
                        }
                    }

                    Console.WriteLine(string.Join(" ", oddParts));
                }
            }

            Console.Write("You crafted ");
            Console.Write(string.Join("", nameParts));
            Console.WriteLine("!");
        }
    }
}

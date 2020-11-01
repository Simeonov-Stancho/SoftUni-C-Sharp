using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                List<string> currentCommand = command
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (currentCommand[0] == "Collect")
                {
                    string item = currentCommand[1];

                    if (items.Contains(item))
                    {
                        continue;
                    }

                    items.Add(item);
                }

                else if (currentCommand[0] == "Drop")
                {
                    string item = currentCommand[1];

                    if (items.Contains(item) == false)
                    {
                        continue;
                    }

                    items.Remove(item);
                }

                else if (currentCommand[0] == "Combine Items")
                {
                    List<string> changeItems = currentCommand[1]
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    string oldItem = changeItems[0];
                    string newItem = changeItems[1];

                    if (items.Contains(oldItem) == false)
                    {
                        continue;
                    }

                    int index = items.IndexOf(oldItem) + 1;
                    items.Insert(index, newItem);
                }

                else if (currentCommand[0] == "Renew")
                {
                    string item = currentCommand[1];

                    if (items.Contains(item) == false)
                    {
                        continue;
                    }

                    items.Remove(item);
                    items.Add(item);
                }
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}

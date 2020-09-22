using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                            .Split('!', StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> currentCommand = command
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                if (currentCommand[0] == "Urgent")
                {
                    string item = currentCommand[1];

                    if (groceries.Contains(item))
                    {
                        continue;
                    }

                    groceries.Insert(0, item);
                }

                else if (currentCommand[0] == "Unnecessary")
                {
                    string item = currentCommand[1];

                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        continue;
                    }
                }

                else if (currentCommand[0] == "Correct")
                {
                    string oldItem = currentCommand[1];
                    string newItem = currentCommand[2];

                    if (groceries.Contains(oldItem))
                    {
                        int index = groceries.IndexOf(oldItem);
                        groceries.Remove(oldItem);
                        groceries.Insert(index, newItem);
                        continue;
                    }
                }

                else if (currentCommand[0] == "Rearrange")
                {
                    string item = currentCommand[1];

                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                        continue;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}

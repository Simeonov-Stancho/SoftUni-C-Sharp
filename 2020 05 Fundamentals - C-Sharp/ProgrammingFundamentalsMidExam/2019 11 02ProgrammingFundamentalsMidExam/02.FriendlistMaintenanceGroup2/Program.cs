using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FriendlistMaintenanceGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string input = string.Empty;
            int blacklistedNamesCount = 0;
            int lostNamesCount = 0;

            while ((input = Console.ReadLine()) != "Report")
            {
                List<string> command = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[0] == "Blacklist")
                {
                    string name = command[1];

                    if (!friendsList.Contains(name))
                    {
                        Console.WriteLine($"{name} was not found.");
                    }

                    else
                    {
                        Console.WriteLine($"{name} was blacklisted.");
                        int index = friendsList.IndexOf(name);

                        friendsList[index] = "Blacklisted";
                        blacklistedNamesCount++;
                    }
                }

                else if (command[0] == "Error")
                {
                    int index = int.Parse(command[1]);
                    string name = friendsList[index];

                    if (name != "Blacklisted" && name != "Lost")
                    {
                        Console.WriteLine($"{name} was lost due to an error.");
                        friendsList[index] = "Lost";
                        lostNamesCount++;
                    }
                }

                else if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];


                    if (index >= 0 && index <= friendsList.Count - 1)
                    {
                        string currentName = friendsList[index];
                        friendsList[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(' ', friendsList));
        }
    }
}

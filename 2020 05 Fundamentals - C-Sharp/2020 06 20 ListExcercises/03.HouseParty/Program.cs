using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> namesList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                List<string> command = input
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .ToList();

                if (command[2] == "going!")
                {
                    namesList = AddNames(namesList, command[0]);
                }

                else if (command[2] == "not")
                {
                    namesList = RemoveNames(namesList, command[0]);
                }
            }

            PrintNames(namesList);
        }

        static List<string> AddNames(List<string> namesList, string name)
        {
            if (namesList.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
            }

            else
            {
                namesList.Add(name);
            }

            return namesList;
        }

        static List<string> RemoveNames(List<string> namesList, string name)
        {
            if (namesList.Contains(name))
            {
                namesList.Remove(name);
            }

            else
            {
                Console.WriteLine($"{name} is not in the list!");
            }

            return namesList;
        }

        static void PrintNames(List<string> namesList)
        {
            for (int i = 0; i < namesList.Count; i++)
            {
                Console.WriteLine(namesList[i]);
            }
        }
    }
}

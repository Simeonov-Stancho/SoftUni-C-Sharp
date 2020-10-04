using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> reservationList = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string input;
            List<string> commands = new List<string>();

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input
                                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                if (command[0] == "Add filter")
                {
                    commands.Add($"{command[1]} {command[2]}");
                }

                else
                {
                    commands.Remove($"{command[1]} {command[2]}");
                }
            }

            for (int i = 0; i < commands.Count; i++)
            {
                string[] currentCommand = commands[i].Split();
                Predicate<string> predicate = GetPredicate(currentCommand);

                reservationList.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", reservationList));

        }

        static Predicate<string> GetPredicate(string[] commands)
        {
            Predicate<string> predicate = null;
            if (commands[0] == "Starts")
            {
                predicate = x => x.StartsWith(commands[2]);
            }

            else if (commands[0] == "Ends")
            {
                predicate = x => x.EndsWith(commands[2]);
            }

            else if (commands[0] == "Length")
            {
                predicate = x => x.Length == int.Parse(commands[1]);
            }

            else if (commands[0] == "Contains")
            {
                predicate = x => x.Contains(commands[1]);
            }

            return predicate;
        }
    }
}

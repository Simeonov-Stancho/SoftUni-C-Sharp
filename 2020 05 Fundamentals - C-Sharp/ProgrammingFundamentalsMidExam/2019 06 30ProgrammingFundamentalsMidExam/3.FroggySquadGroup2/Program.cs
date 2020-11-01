using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.FroggySquadGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<String> commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (commands[0] != "Print")
            {
                if (commands[0] == "Join")
                {
                    JoinFrog(frogNames, commands);
                }

                else if (commands[0] == "Jump")
                {
                    JumpFrog(frogNames, commands);
                }

                else if (commands[0] == "Dive")
                {
                    DiveFrog(frogNames, commands);
                }

                else if (commands[0] == "First")
                {
                    Console.WriteLine(string.Join(" ", FirstFrog(frogNames, commands)));
                }

                else if (commands[0] == "Last")
                {
                    Console.WriteLine(string.Join(" ", LastFrog(frogNames, commands)));
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            if (commands[1] == "Normal")
            {
                Console.Write("Frogs: ");
                Console.WriteLine(string.Join(" ", frogNames));
            }

            else
            {
                frogNames.Reverse();
                Console.Write("Frogs: ");
                Console.WriteLine(string.Join(" ", frogNames));
            }
        }

        static List<string> JoinFrog(List<string> frogNames, List<string> commands)
        {
            frogNames.Add(commands[1]);
            return frogNames;
        }

        static List<string> JumpFrog(List<string> frogNames, List<string> commands)
        {
            int index = int.Parse(commands[2]);
            string name = commands[1];

            if (index >= 0 && index < frogNames.Count)
            {
                frogNames.Insert(index, name);
            }

            return frogNames;
        }

        static List<string> DiveFrog(List<string> frogNames, List<string> commands)
        {
            int index = int.Parse(commands[1]);

            if (index >= 0 && index < frogNames.Count)
            {
                frogNames.RemoveAt(index);
            }

            return frogNames;
        }

        static List<string> FirstFrog(List<string> frogNames, List<string> commands)
        {
            int count = int.Parse(commands[1]);
            List<string> firstFrogs = new List<string>();

            for (int i = 0; i < count; i++)
            {
                if (i == (frogNames.Count))
                {
                    break;
                }

                firstFrogs.Add(frogNames[i]);
            }

            return firstFrogs;
        }

        static List<string> LastFrog(List<string> frogNames, List<string> commands)
        {
            int count = int.Parse(commands[1]);
            List<string> lastFrogs = new List<string>();

            int startIndex = frogNames.Count - count;

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            for (int i = startIndex; i < frogNames.Count; i++)
            {
                lastFrogs.Add(frogNames[i]);
            }

            return lastFrogs;
        }
    }
}

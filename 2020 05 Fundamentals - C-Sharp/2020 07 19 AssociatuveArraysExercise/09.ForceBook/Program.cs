using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[1] == "|" || command[2] == "|")
                {
                    command = input
                       .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                    string forceSide = command[0];
                    string forceUser = command[1];

                    if (forceBook.Any(x=>x.Value.Contains(forceUser)))
                    {
                        continue;
                    }

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                        forceBook[forceSide].Add(forceUser);
                    }

                    else
                    {
                        if (!forceBook[forceSide].Contains(forceUser))
                        {
                            forceBook[forceSide].Add(forceUser);
                        }
                    }
                }

                else
                {
                    command = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string forceUser = command[0];
                    string changeForceSide = command[1];
                    bool isContain = false;
                    string userSide = string.Empty;

                    foreach (var pair in forceBook)
                    {
                        if (pair.Value.Contains(forceUser))
                        {
                            isContain = true;
                            userSide = pair.Key;
                        }
                    }

                    if (isContain)
                    {
                        forceBook[userSide].Remove(forceUser);

                        if (!forceBook.ContainsKey(changeForceSide))
                        {
                            forceBook.Add(changeForceSide, new List<string>());
                            forceBook[changeForceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {changeForceSide} side!");
                        }

                        else
                        {
                            if (!forceBook[changeForceSide].Contains(forceUser))
                            {
                                forceBook[changeForceSide].Add(forceUser);
                                Console.WriteLine($"{forceUser} joins the {changeForceSide} side!");
                            }
                        }
                    }

                    else
                    {
                        if (!forceBook.ContainsKey(changeForceSide))
                        {
                            forceBook.Add(changeForceSide, new List<string>());
                            forceBook[changeForceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {changeForceSide} side!");
                        }

                        else
                        {
                            if (!forceBook[changeForceSide].Contains(forceUser))
                            {
                                forceBook[changeForceSide].Add(forceUser);
                                Console.WriteLine($"{forceUser} joins the {changeForceSide} side!");
                            }
                        }
                    }
                }
            }

            forceBook = forceBook
                        .OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in forceBook)
            {
                pair.Value.Sort();

                if (pair.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.WriteLine($"! {pair.Value[i]}");
                }
            }
        }
    }
}

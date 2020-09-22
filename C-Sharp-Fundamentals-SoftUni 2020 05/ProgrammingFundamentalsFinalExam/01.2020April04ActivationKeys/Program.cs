using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2020April04ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                List<string> commands = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                   .ToList();

                if (commands[0] == "Contains")
                {
                    string substring = commands[1];

                    if (rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }

                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (commands[0] == "Flip")
                {
                    string command = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        char current = rawActivationKey[i];
                        if (char.IsNumber(rawActivationKey[i]))
                        {
                            continue;
                        }
                        else if (command == "Lower")
                        {
                            rawActivationKey = rawActivationKey.Remove(i, 1).Insert(i, char.ToLower(rawActivationKey[i]).ToString());
                        }

                        else
                        {
                            rawActivationKey = rawActivationKey.Remove(i, 1).Insert(i, char.ToUpper(rawActivationKey[i]).ToString());
                        }
                    }

                    Console.WriteLine(rawActivationKey);
                }

                else if (commands[0] == "Slice")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int length = endIndex - startIndex;

                    rawActivationKey = rawActivationKey.Remove(startIndex, length);

                    Console.WriteLine(rawActivationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}

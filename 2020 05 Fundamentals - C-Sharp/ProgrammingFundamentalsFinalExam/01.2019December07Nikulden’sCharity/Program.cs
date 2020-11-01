using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019December07Nikulden_sCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Finish")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Replace")
                {
                    string currentChar = commands[1];
                    string newChar = commands[2];

                    text = text.Replace(currentChar, newChar);
                    Console.WriteLine(text);
                }

                else if (commands[0] == "Cut")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if ((startIndex >= 0 && startIndex < text.Length)
                        && (endIndex >= startIndex && endIndex < text.Length))
                    {
                        text = text.Remove(startIndex, (endIndex - startIndex+1));
                        Console.WriteLine(text);
                    }

                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                else if (commands[0] == "Make")
                {
                    if (commands[1] == "Upper")
                    {
                        text = text.ToUpper();
                    }

                    else if (commands[1] == "Lower")
                    {
                        text = text.ToLower();
                    }

                    Console.WriteLine(text);
                }

                else if (commands[0] == "Check")
                {
                    if (text.Contains(commands[1]))
                    {
                        Console.WriteLine($"Message contains {commands[1]}");
                    }

                    else
                    {
                        Console.WriteLine($"Message doesn't contain {commands[1]}");
                    }
                }

                else if (commands[0] == "Sum")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int sum = 0;

                    if ((startIndex >= 0 && startIndex < text.Length)
                        && (endIndex >= startIndex && endIndex < text.Length))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += text[i];
                        }

                        Console.WriteLine(sum);
                    }

                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}

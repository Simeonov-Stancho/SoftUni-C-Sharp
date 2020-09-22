using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019August03StringManipulatorGr1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Translate")
                {
                    string currentChar = commands[1];
                    string replacement = commands[2];

                    text = text.Replace(currentChar, replacement);
                    Console.WriteLine(text);
                }

                else if (commands[0] == "Includes")
                {
                    if (text.Contains(commands[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (commands[0] == "Start")
                {
                    if (text.StartsWith(commands[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (commands[0] == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }

                else if (commands[0] == "FindIndex")
                {
                    int index = text.LastIndexOf(commands[1]);
                    Console.WriteLine(index);
                }

                else if (commands[0]=="Remove")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);
                    text = text.Remove(startIndex, count);

                    Console.WriteLine(text);
                }
            }
        }
    }
}

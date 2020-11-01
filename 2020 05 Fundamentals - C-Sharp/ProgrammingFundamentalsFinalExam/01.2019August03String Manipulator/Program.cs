using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019August03String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = string.Empty;


            while ((input = Console.ReadLine()) != "Done")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Change")
                {
                    text = text.Replace(commands[1], commands[2]);

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

                else if (commands[0] == "End")
                {
                    if (text.EndsWith(commands[1]))
                    {
                        Console.WriteLine("True");
                    }

                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                else if (commands[0] == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }

                else if (commands[0] == "FindIndex")
                {
                    int index = text.IndexOf(commands[1]);
                    Console.WriteLine(index);
                }

                else if (commands[0] == "Cut")
                {
                    int startIndex = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);
                    string newString = string.Empty;
                    text = text.Substring(startIndex, length);

                    Console.WriteLine(text);
                }
            }
        }
    }
}

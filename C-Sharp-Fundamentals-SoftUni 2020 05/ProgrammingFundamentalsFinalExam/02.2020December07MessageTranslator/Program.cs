using System;
using System.Text.RegularExpressions;

namespace _02._2020December07MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"!(?<command>[A-Z][a-z]{3,})!:\[(?<message>[A-Za-z]{8,})\]";
                Regex regex = new Regex(pattern);
                Match validMessage = regex.Match(input);

                if (regex.IsMatch(input))
                {
                    string message = validMessage.Groups["message"].Value;

                    Console.Write($"{validMessage.Groups["command"].Value}: ");

                    for (int j = 0; j < message.Length; j++)
                    {
                        int currentASCIINum = message[j];
                        Console.Write($"{currentASCIINum}");
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}

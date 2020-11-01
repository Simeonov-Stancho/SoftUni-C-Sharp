using System;
using System.Text.RegularExpressions;

namespace _02._2019August03MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string pattern = @"^([\$\%])(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<third>[0-9]+)\]\|$";
                Regex regex = new Regex(pattern);
                Match validMessage = regex.Match(input);

                if (regex.IsMatch(input))
                {
                    int first = int.Parse(validMessage.Groups["first"].Value);
                    int second = int.Parse(validMessage.Groups["second"].Value);
                    int third = int.Parse(validMessage.Groups["third"].Value);

                    string all = Char.ConvertFromUtf32(first) + Char.ConvertFromUtf32(second) + Char.ConvertFromUtf32(third);

                    Console.WriteLine($"{validMessage.Groups["tag"]}: {all}");
                }

                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}

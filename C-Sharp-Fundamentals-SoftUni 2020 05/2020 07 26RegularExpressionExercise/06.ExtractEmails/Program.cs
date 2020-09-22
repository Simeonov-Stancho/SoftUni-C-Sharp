using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[._-]*[A-Za-z0-9]*)@(?<host>[A-Za-z]+?([.-][A-Za-z]*)*(\.[A-Za-z]{2,}))";
            Regex regex = new Regex(pattern);

            MatchCollection validEmails = regex.Matches(input);

            Console.WriteLine(string.Join(Environment.NewLine, validEmails));

        }
    }
}

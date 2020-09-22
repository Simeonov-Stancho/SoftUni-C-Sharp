using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(names);

            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }
        }
    }
}

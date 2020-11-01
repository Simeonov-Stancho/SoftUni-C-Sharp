using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359)([-]?[ ]?)(2)(\2)(\d{3})(\2)(\d{4})\b";

            string phonesNumbers = Console.ReadLine();
            var tryIt = Regex.Matches(phonesNumbers, pattern);

            Regex phonesMatch = new Regex(pattern);

            var mathes = phonesMatch.Matches(phonesNumbers);
            List<string> matchedNumbers = new List<string>();

            foreach (Match match in mathes)
            {
                matchedNumbers.Add(match.Value);
            }

            Console.Write(string.Join(", ", matchedNumbers));
        }
    }
}

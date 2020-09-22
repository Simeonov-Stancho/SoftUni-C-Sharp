using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>[0-9][0-9])([-.\/])(?<month>[A-Z][a-z][a-z])(\1)(?<year>[0-9]{4})\b";

            Regex dateMatches = new Regex(pattern);

            MatchCollection matches = dateMatches.Matches(input);

            foreach (Match date in matches)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}

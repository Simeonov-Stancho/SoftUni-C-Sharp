using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>[0-9][0-9])([-.\/])(?<month>[A-Z][a-z][a-z])(\1)(?<year>\d{4})\b";
            //string pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            Regex dateMatches = new Regex(pattern);

            MatchCollection matches = dateMatches.Matches(input);

            foreach (Match date in matches)
            {
                int day = int.Parse(date.Groups["day"].Value);
                string month = date.Groups["month"].Value;
                int year = int.Parse(date.Groups["year"].Value);

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}

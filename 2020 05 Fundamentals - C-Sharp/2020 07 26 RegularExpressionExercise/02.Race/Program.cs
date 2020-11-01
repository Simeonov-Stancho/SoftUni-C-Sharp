using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;
            int distance = 0;
            Dictionary<string, int> participants = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end of race")
            {
                string currentName = string.Empty;
                int currentDistance = 0;

                string pattern = @"[A-Za-z]";
                Regex nameMatch = new Regex(pattern);
                MatchCollection name = nameMatch.Matches(input);

                for (int i = 0; i < name.Count; i++)
                {
                    currentName += name[i];
                }

                string patternNum = @"[0-9]";
                Regex distanceMatch = new Regex(patternNum);
                MatchCollection match = distanceMatch.Matches(input);

                for (int i = 0; i < match.Count; i++)
                {
                    currentDistance += int.Parse(match[i].Value);
                }

                if ((racers.Contains(currentName))
                    && (!participants.ContainsKey(currentName)))
                {
                    participants.Add(currentName, currentDistance);
                }

                else if ((racers.Contains(currentName))
                    && (participants.ContainsKey(currentName)))
                {
                    participants[currentName] += currentDistance;
                }
            }

            participants = participants.OrderByDescending(x => x.Value)
                                        .ToDictionary(x => x.Key, x => x.Value);

            List<string> possitions = new List<string>(participants.Keys);

            Console.WriteLine($"1st place: {possitions[0]}");
            Console.WriteLine($"2nd place: {possitions[1]}");
            Console.WriteLine($"3rd place: {possitions[2]}");
        }
    }
}

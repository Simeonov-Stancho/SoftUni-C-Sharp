using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] command = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[1] == "banned")
                {
                    string userName = command[0];

                    if (results.ContainsKey(userName))
                    {
                        results.Remove(userName);
                    }
                }

                else
                {
                    string userName = command[0];
                    string language = command[1];
                    int points = int.Parse(command[2]);

                    if (!results.ContainsKey(userName))
                    {
                        results.Add(userName, points);

                        if (languages.ContainsKey(language))
                        {
                            languages[language]++;
                            continue;
                        }

                        languages.Add(language, 1);
                    }

                    else
                    {
                        languages[language]++;

                        if (results[userName] < points)
                        {
                            results[userName] = points;
                        }
                    }
                }
            }

            results = results.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            languages = languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var pair in results)
            {
                Console.WriteLine(pair.Key + " | " + pair.Value);
            }

            Console.WriteLine("Submissions:");

            foreach (var pair in languages)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
        }
    }
}
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
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> bannedUser = new Dictionary<string, int>();
            Dictionary<string, int> secondDictionary = new Dictionary<string, int>();

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
                        secondDictionary = results[userName];
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
                        results.Add(userName, new Dictionary<string, int>());
                        results[userName].Add(language, points);
                    }

                    else
                    {
                        if (results[userName][language] < points)
                        {
                            results[userName][language] = points;
                        }
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var pair in results)
            {
                secondDictionary = pair.Value;
                Console.Write(pair.Key + " | ");
                foreach (var pairs in secondDictionary)
                {
                    Console.WriteLine(pairs.Value);
                }
            }
        }

        //public class UserResult
        //{
        //    public string UserName { get; set; }
        //    public string Language { get; set; }
        //    public int Points { get; set; }

        //    public UserResult(string userName, string language, int points)
        //    {
        //        this.UserName = userName;
        //        this.Language = language;
        //        this.Points = points;
        //    }
        //}
    }
}


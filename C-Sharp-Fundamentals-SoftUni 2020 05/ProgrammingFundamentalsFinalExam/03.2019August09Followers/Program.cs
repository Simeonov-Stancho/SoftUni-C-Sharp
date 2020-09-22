using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._2019August09Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<int>> followers = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Log out")
            {
                List<string> commands = input
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "New follower")
                {
                    string userName = commands[1];

                    if (!followers.ContainsKey(userName))
                    {
                        followers.Add(userName, new List<int>());
                        followers[userName].Add(0);
                        followers[userName].Add(0);
                    }
                }

                else if (commands[0] == "Like")
                {
                    string userName = commands[1];
                    int count = int.Parse(commands[2]);

                    if (!followers.ContainsKey(userName))
                    {
                        followers.Add(userName, new List<int>());
                        followers[userName].Add(count);
                        followers[userName].Add(0);
                    }

                    else
                    {
                        followers[userName][0] += count;
                    }
                }

                else if (commands[0] == "Comment")
                {
                    string userName = commands[1];

                    if (!followers.ContainsKey(userName))
                    {
                        followers.Add(userName, new List<int>());
                        followers[userName].Add(0);
                        followers[userName].Add(1);
                    }

                    else
                    {
                        followers[userName][1]++;
                    }
                }

                else if (commands[0] == "Blocked")
                {
                    string userName = commands[1];
                    if (!followers.ContainsKey(userName))
                    {
                        Console.WriteLine($"{userName} doesn't exist.");
                    }

                    else
                    {
                        followers.Remove(userName);
                    }
                }
            }

            followers = followers
                    .OrderByDescending(x => x.Value[0])
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{followers.Count} followers");

            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value[0] + follower.Value[1]}");
            }
        }
    }
}

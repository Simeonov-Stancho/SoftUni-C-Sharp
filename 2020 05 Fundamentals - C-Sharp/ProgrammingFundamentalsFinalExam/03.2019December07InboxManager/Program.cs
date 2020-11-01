using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._2019December07InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> usersInfo = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                List<string> commands = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Add")
                {
                    string userName = commands[1];

                    if (!usersInfo.ContainsKey(userName))
                    {
                        usersInfo.Add(userName, new List<string>());
                    }

                    else
                    {
                        Console.WriteLine($"{userName} is already registered");
                    }
                }

                else if (commands[0] == "Send")
                {
                    string userName = commands[1];
                    string email = commands[2];

                    if (usersInfo.ContainsKey(userName))
                    {
                        usersInfo[userName].Add(email);
                    }
                }

                else if (commands[0] == "Delete")
                {
                    string userName = commands[1];

                    if (usersInfo.ContainsKey(userName))
                    {
                        usersInfo.Remove(userName);
                    }

                    else
                    {
                        Console.WriteLine($"{userName} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {usersInfo.Count}");

            usersInfo = usersInfo
                        .OrderByDescending(x => x.Value.Count)
                        .ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in usersInfo)
            {
                Console.WriteLine(user.Key);

                for (int i = 0; i < user.Value.Count; i++)
                {
                    Console.WriteLine($"- {user.Value[i]}");
                }
            }
        }
    }
}

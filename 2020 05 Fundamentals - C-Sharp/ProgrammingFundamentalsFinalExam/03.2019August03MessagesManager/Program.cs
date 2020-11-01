using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._2019August03MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            string input = string.Empty;
            Dictionary<string, List<int>> userInformation = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                List<string> commands = input
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Add")
                {
                    string userName = commands[1];
                    int sentNum = int.Parse(commands[2]);
                    int receivedNum = int.Parse(commands[3]);

                    if (!userInformation.ContainsKey(userName))
                    {
                        userInformation.Add(userName, new List<int>());
                        userInformation[userName].Add(sentNum);
                        userInformation[userName].Add(receivedNum);
                    }
                }

                else if (commands[0] == "Message")
                {
                    string sender = commands[1];
                    string receiver = commands[2];

                    if (userInformation.ContainsKey(sender) && userInformation.ContainsKey(receiver))
                    {
                        userInformation[sender][0]++;
                        if (userInformation[sender][0] + userInformation[sender][1] >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            userInformation.Remove(sender);
                        }

                        userInformation[receiver][1]++;
                        if (userInformation[receiver][1] + userInformation[receiver][0] >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            userInformation.Remove(receiver);
                        }
                    }
                }

                else if (commands[0] == "Empty")
                {
                    string userName = commands[1];
                    if (userName == "All")
                    {
                        userInformation.Clear();
                        continue;
                    }

                    if (userInformation.ContainsKey(userName))
                    {
                        userInformation.Remove(userName);
                    }

                }
            }

            userInformation = userInformation
                    .OrderByDescending(x => x.Value[1])
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {userInformation.Count}");

            foreach (var user in userInformation)
            {
                Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
            }
        }
    }
}

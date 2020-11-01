using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> userInformation = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string userName = command[1];

                if (command[0] == "register")
                {
                    string licensePlateNumber = command[2];

                    if (!userInformation.ContainsKey(userName))
                    {
                        userInformation.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }

                else if (command[0] == "unregister")
                {
                    if (!userInformation.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }

                    else
                    {
                        userInformation.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var pair in userInformation)
            {
                Console.WriteLine(pair.Key + " => " + pair.Value);
            }

        }
    }
}

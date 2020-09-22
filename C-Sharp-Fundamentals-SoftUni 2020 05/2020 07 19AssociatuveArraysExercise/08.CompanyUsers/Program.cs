using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" -> ")
                    .ToArray();

                string companyName = command[0];
                string employeeId = command[1];

                if (!companyUsers.ContainsKey(companyName))
                {
                    companyUsers.Add(companyName, new List<string>());
                    companyUsers[companyName].Add(employeeId);
                }

                else
                {
                    if (companyUsers[companyName].Contains(employeeId))
                    {
                        continue;
                    }

                    companyUsers[companyName].Add(employeeId);
                }
            }

            companyUsers = companyUsers.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in companyUsers)
            {
                Console.WriteLine(pair.Key);

                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.WriteLine($"-- {pair.Value[i]}");
                }
            }
        }
    }
}
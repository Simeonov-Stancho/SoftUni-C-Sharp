using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = input[0];
                string countrie = input[1];
                string cities = input[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentsInfo[continent].ContainsKey(countrie))
                {
                    continentsInfo[continent].Add(countrie, new List<string>());
                }

                continentsInfo[continent][countrie].Add(cities);
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine($"{ continent.Key}:");

                foreach (var countrie in continent.Value)
                {
                    Console.WriteLine("  " + countrie.Key + " -> " + string.Join(", ", countrie.Value));
                }
            }
        }
    }
}

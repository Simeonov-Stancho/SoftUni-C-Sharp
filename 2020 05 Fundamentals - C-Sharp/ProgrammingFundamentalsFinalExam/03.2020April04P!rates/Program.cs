using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03._2020April04P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Sail")
            {
                List<string> townData = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string town = townData[0];
                int population = int.Parse(townData[1]);
                int gold = int.Parse(townData[2]);

                if (!cities.ContainsKey(town))
                {
                    cities.Add(town, new List<int>());
                    cities[town].Add(population);
                    cities[town].Add(gold);
                    continue;
                }

                cities[town][0] += population;
                cities[town][1] += gold;
            }

            input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commands = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Plunder")
                {
                    string town = commands[1];
                    int people = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);

                    int currentPopulation = cities[town][0];
                    int currentGold = cities[town][1];

                    cities[town][0] -= people;
                    cities[town][1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[town][0] <= 0 || cities[town][1] <= 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }

                else if (commands[0] == "Prosper")
                {
                    string town = commands[1];
                    int gold = int.Parse(commands[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    cities[town][1] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                }
            }

            cities = cities
                .OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var town in cities)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
        }
    }
}

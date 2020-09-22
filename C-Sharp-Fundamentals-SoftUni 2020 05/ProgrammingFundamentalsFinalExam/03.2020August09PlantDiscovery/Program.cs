using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace _03._2020August09PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plantRarity = new Dictionary<string, List<double>>();
            Dictionary<string, List<int>> plantRating = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<string> plants = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string plant = plants[0];
                int rarity = int.Parse(plants[1]);

                if (plantRarity.ContainsKey(plant))
                {
                    plantRarity[plant][0] = rarity;           //"update"-what its mean 
                    continue;
                }

                plantRarity.Add(plant, new List<double>());
                plantRarity[plant].Add(rarity);
                plantRating.Add(plant, new List<int>());
            }


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                List<string> command = input
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "Rate")
                {
                    string currentPlant = command[1];
                    int currentRating = int.Parse(command[2]);

                    if (!plantRating.ContainsKey(currentPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    plantRating[currentPlant].Add(currentRating);
                }

                else if (command[0] == "Update")
                {
                    string currentPlant = command[1];
                    int newRarity = int.Parse(command[2]);

                    if (!plantRarity.ContainsKey(currentPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    plantRarity[currentPlant][0] = newRarity;
                }

                else if (command[0] == "Reset")
                {
                    string currentPlant = command[1];
                    if (!plantRating.ContainsKey(currentPlant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    plantRating.Remove(currentPlant);
                    plantRating.Add(currentPlant, new List<int>());
                }
            }

            foreach (var plant in plantRating)
            {
                int sum = 0;
                int count = 0;
                double averageSum = 0;

                sum = plant.Value.Sum();

                if (plant.Value.Count == 0)
                {
                    averageSum = 0;
                    plantRarity[plant.Key].Add(averageSum);
                    continue;
                }

                averageSum = sum * 1.0 / plant.Value.Count;

                plantRarity[plant.Key].Add(averageSum);
            }

            plantRarity = plantRarity
                .OrderByDescending(x => x.Value[0])
                .ThenByDescending(x => x.Value[1])
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plantRarity)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }
        }
    }
}
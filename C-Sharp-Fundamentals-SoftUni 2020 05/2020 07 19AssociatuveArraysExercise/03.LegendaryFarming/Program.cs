using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> materialsQuantity = new Dictionary<string, int>();
            bool isObtained = false;
            string key = string.Empty;
            int value = 0;
            string materials = string.Empty;

            while (!isObtained)
            {
                for (int i = 1; i < input.Length; i += 2)
                {
                    if (i % 2 != 0)
                    {
                        value = int.Parse(input[i - 1]);
                        key = input[i].ToLower();

                        if (materialsQuantity.ContainsKey(key))
                        {
                            materialsQuantity[key] += value;
                        }

                        else
                        {
                            materialsQuantity.Add(key, value);
                        }

                        if ((key == "motes" || key == "shards" || key == "fragments")
                            && materialsQuantity[key] >= 250)
                        {
                            switch (key)
                            {
                                case "motes":
                                    materials = "Dragonwrath";
                                    break;

                                case "shards":
                                    materials = "Shadowmourne";
                                    break;

                                case "fragments":
                                    materials = "Valanyr";
                                    break;
                            }

                            isObtained = true;

                            Console.WriteLine(materials + " obtained!");

                            Dictionary<string, int> remainingMaterials = materialsQuantity;
                            remainingMaterials[key] -= 250;

                            Dictionary<string, int> legendaryMaterials = new Dictionary<string, int>();
                            legendaryMaterials.Add("shards", 0);
                            legendaryMaterials.Add("fragments", 0);
                            legendaryMaterials.Add("motes", 0);

                            Dictionary<string, int> otherMaterials = new Dictionary<string, int>();

                            foreach (var pairs in remainingMaterials)
                            {
                                if (pairs.Key == "shards" || pairs.Key == "fragments" || pairs.Key == "motes")
                                {
                                    legendaryMaterials[pairs.Key] += pairs.Value;
                                }

                                else
                                {
                                    otherMaterials.Add(pairs.Key, pairs.Value);
                                }
                            }

                            legendaryMaterials = legendaryMaterials
                                .OrderByDescending(x => x.Value)
                                .ThenBy(x => x.Key)
                                .ToDictionary(x => x.Key, x => x.Value);

                            foreach (var pairs in legendaryMaterials)
                            {
                                Console.WriteLine(pairs.Key + ": " + pairs.Value);
                            }

                            otherMaterials = otherMaterials
                                .OrderBy(x => x.Key)
                                .ToDictionary(x => x.Key, x => x.Value);

                            foreach (var pairs in otherMaterials)
                            {
                                Console.WriteLine(pairs.Key + ": " + pairs.Value);
                            }
                            break;
                        }
                    }
                }

                if (!isObtained)
                {
                    input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _2.TreasureHuntWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> commands = input
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToList();

                if (commands[0] == "Loot")
                {
                    LootItems(chest, commands);
                }

                else if (commands[0] == "Drop")
                {
                    DropItems(chest, commands);
                }

                else if (commands[0] == "Steal")
                {
                    StealItems(chest, commands);
                }
            }

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }
            double averageGain = CalculateAverageTreasureGain(chest);

            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
        }

        static List<string> LootItems(List<string> chest, List<string> commands)
        {
            for (int i = 1; i < commands.Count; i++)
            {
                string currentItems = commands[i];
                if (!chest.Contains(currentItems))
                {
                    chest.Insert(0, currentItems);
                }
            }

            return chest;
        }

        static List<string> DropItems(List<string> chest, List<string> commands)
        {
            int index = int.Parse(commands[1]);

            if (index >= 0 && index < chest.Count)
            {
                string currentItem = chest[index];
                chest.RemoveAt(index);
                chest.Add(currentItem);
            }

            return chest;
        }

        static List<string> StealItems(List<string> chest, List<string> commands)
        {
            int count = int.Parse(commands[1]);
            int index = chest.Count - count;
            
            if (index < 0)
            {
                index = 0;
            }

            int realCount = chest.Count - index;

            List<string> stealedItems = new List<string>();

            for (int i = index; i < chest.Count; i++)
            {
                stealedItems.Add(chest[i]);
            }
            Console.WriteLine(string.Join(", ", stealedItems));
            chest.RemoveRange(index, realCount);

            return chest;
        }

        static double CalculateAverageTreasureGain(List<string> chest)
        {
            double sum = 0;
            double count = chest.Count;

            for (int i = 0; i < chest.Count; i++)
            {
                string currentItems = chest[i];
                sum += currentItems.Length;
            }

            double averageGain = sum / count;

            return averageGain;
        }
    }
}

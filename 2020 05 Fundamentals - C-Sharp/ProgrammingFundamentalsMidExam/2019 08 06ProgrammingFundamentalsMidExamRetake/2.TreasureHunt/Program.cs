using System;
using System.Linq;

namespace _2.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chest = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] commands = input
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                if (commands[0] == "Loot")
                {
                    LootItems(chest, commands);
                }
            }
        }

        static string[] LootItems(string[] chest, string[] commands)
        {
            string newChest = 
            for (int i = 1; i < commands.Length; i++)
            {
                string currentItem = commands[i];

                for (int j = 0; j < chest.Length; j++)
                {
                    if (currentItem == chest[j])
                    {

                    }
                }
            }

            return chest;
        }
    }
}

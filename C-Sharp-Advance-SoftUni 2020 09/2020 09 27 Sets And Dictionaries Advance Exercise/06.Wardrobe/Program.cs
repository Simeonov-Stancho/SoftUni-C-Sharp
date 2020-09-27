using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine()
                .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string color = clothes[0];

                for (int j = 1; j < clothes.Length; j++)
                {
                    string clothing = clothes[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobe[color].ContainsKey(clothing))
                    {
                        wardrobe[color].Add(clothing, 1);
                    }

                    else
                    {
                        wardrobe[color][clothing]++;
                    }
                }
            }

            string[] searchedClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string searchedColor = searchedClothes[0];
            string searchedClothing = searchedClothes[1];

            foreach (var clothing in wardrobe)
            {
                Console.WriteLine($"{clothing.Key} clothes:");

                foreach (var dress in clothing.Value)
                {
                    if ((clothing.Key == searchedColor) 
                     && (dress.Key == searchedClothing))
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {dress.Key} - {dress.Value}");
                }
            }
        }
    }
}
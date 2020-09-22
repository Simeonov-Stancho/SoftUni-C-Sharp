using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

                if (commands[0] == "Include")
                {
                    shops.Add(commands[1]);
                }

                else if (commands[0] == "Visit")
                {
                    if (commands[1] == "first")
                    {
                        int numberOfShops = int.Parse(commands[2]);

                        if (numberOfShops <= shops.Count)
                        {
                            shops.RemoveRange(0, numberOfShops);
                        }
                    }

                    else if (commands[1] == "last")
                    {
                        int numberOfShops = int.Parse(commands[2]);

                        if (numberOfShops <= shops.Count)
                        {
                            int startIndex = shops.Count - numberOfShops;
                            shops.RemoveRange(startIndex, numberOfShops);
                        }
                    }
                }

                else if (commands[0] == "Prefer")
                {
                    int firstIndex = int.Parse(commands[1]);
                    int secondIndex = int.Parse(commands[2]);

                    if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < shops.Count && secondIndex < shops.Count)
                    {
                        string firstShop = shops[firstIndex];
                        string secondShop = shops[secondIndex];

                        shops[firstIndex] = secondShop;
                        shops[secondIndex] = firstShop;
                    }
                }

                else if (commands[0] == "Place")
                {
                    string shop = commands[1];
                    int index = int.Parse(commands[2]);

                    if (index >= 0 && index < shops.Count)
                    {
                        shops.Insert(index + 1, shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(' ', shops));
        }
    }
}

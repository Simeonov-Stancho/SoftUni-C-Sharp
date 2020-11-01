using System;
using System.Linq;

namespace _02.Hello_France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double budget = double.Parse(Console.ReadLine());
            double profit = 0;
            double savedSum = 0;

            for (int i = 0; i < items.Length; i++)
            {
                string[] currentItems = items[i]
                .Split("->", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                double currentPrice = double.Parse(currentItems[1]);

                if (currentItems[0] == "Clothes")
                {
                    if (currentPrice <= 50.00 && currentPrice <= budget)
                    {
                        budget -= currentPrice;
                        profit += (currentPrice * 0.4);
                        Console.Write($"{(currentPrice * 1.4):f2} ");
                    }
                }

                else if (currentItems[0] == "Shoes")
                {
                    if (currentPrice <= 35.00 && currentPrice <= budget)
                    {
                        budget -= currentPrice;
                        profit += (currentPrice * 0.4);
                        Console.Write($"{(currentPrice * 1.4):f2} ");
                    }

                }

                else if (currentItems[0] == "Accessories")
                {
                    if (currentPrice <= 20.5 && currentPrice <= budget)
                    {
                        budget -= currentPrice;
                        profit += (currentPrice * 0.4);
                        Console.Write($"{(currentPrice * 1.4):f2} ");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");

            savedSum = budget + profit + profit / 0.4;

            if (savedSum >= 150)
            {
                Console.WriteLine("Hello, France!");
            }

            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}

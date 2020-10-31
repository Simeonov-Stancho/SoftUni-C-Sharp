using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0;
            double totalCosts = 0;

            switch (flowersType)
            {
                case "Roses":
                    if (flowersCount > 80)
                    {
                        price = 5 * 0.9;
                    }
                    else
                    {
                        price = 5;
                    }
                break;

                case "Dahlias":
                    if (flowersCount > 90)
                    {
                        price = 3.8 * 0.85;
                    }
                    else
                    {
                        price = 3.8;
                    }
                    break;

                case "Tulips":
                    if (flowersCount > 80)
                    {
                        price = 2.8 * 0.85;
                    }
                    else
                    {
                        price = 2.8;
                    }
                    break;

                case "Narcissus":
                    if (flowersCount < 120)
                    {
                        price = 3 * 1.15;
                    }
                    else
                    {
                        price = 3;
                    }
                    break;

                case "Gladiolus":
                    if (flowersCount < 80)
                    {
                        price = 2.5 *1.2;
                    }
                    else
                    {
                        price = 2.5;
                    }
                    break;
                
            }
            totalCosts = flowersCount * price;

            if (budget >= totalCosts)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowersType} and { budget - totalCosts:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalCosts - budget:f2} leva more.");
            }
        }
    }
}

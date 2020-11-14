using System;

namespace _02SummerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double umbrellaPrice = 2.0 / 3 * towelPrice;
            double sumerShoesPrice = 0.75 * umbrellaPrice;
            double beachBagPrice = 1.0 / 3 * (towelPrice + sumerShoesPrice);

            double costs = towelPrice + umbrellaPrice + sumerShoesPrice + beachBagPrice;
            double totalCosts = costs - ( costs * discount/100);

            if (budget>= totalCosts)
            {
                Console.WriteLine($"Annie's sum is {totalCosts:f2} lv. She has {(budget - totalCosts):f2} lv. left.");
            }

            else
            {
                Console.WriteLine($"Annie's sum is {totalCosts:f2} lv. She needs {(totalCosts - budget):f2} lv. more.");
            }
        }
    }
}

using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double floorPrice = double.Parse(Console.ReadLine());

            double eggPrice = 0.75 * floorPrice;
            double milkPrice = 1.25 * floorPrice * 0.25;

            int cozonacs = 0;
            int coloredEggs = 0;
            double currentCosts = 0;

            while (budget > currentCosts)
            {
                currentCosts += (eggPrice + floorPrice + milkPrice);

                if (currentCosts > budget)
                {
                    currentCosts -= (eggPrice + floorPrice + milkPrice);
                    break;
                }
                cozonacs++;
                coloredEggs += 3;

                if (cozonacs % 3 == 0)
                {
                    coloredEggs -= (cozonacs - 2);
                }
            }

            Console.WriteLine($"You made {cozonacs} cozonacs! Now you have {coloredEggs} eggs and {(budget-currentCosts):f2}BGN left.");
        }
    }
}

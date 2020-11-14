using System;

namespace _06BakingCompetition
{
    class Program
    {
        static void Main(string[] args)
        {

            int players = int.Parse(Console.ReadLine());
            int totalCounts = 0;
            double totalSum = 0;
            for (int i = 1; i <= players; i++)
            {
                int cookiesCount = 0;
                int cakesCount = 0;
                int wafflesCount = 0;

                string name = Console.ReadLine();
                string kind = Console.ReadLine();

                while (kind != "Stop baking!")
                {
                    int pcs = int.Parse(Console.ReadLine());
                    totalCounts += pcs;
                    switch (kind)
                    {
                        case "cookies":
                            cookiesCount += pcs;
                            break;

                        case "cakes":
                            cakesCount += pcs;
                            break;

                        case "waffles":
                            wafflesCount += pcs;
                            break;
                    }

                    kind = Console.ReadLine();

                }
                Console.WriteLine($"{name} baked {cookiesCount} cookies, {cakesCount} cakes and { wafflesCount} waffles.");
                double sum = cookiesCount * 1.5 + cakesCount * 7.80 + wafflesCount * 2.30;
                totalSum += sum;
            }

            Console.WriteLine($"All bakery sold: {totalCounts}");
            Console.WriteLine($"Total sum for charity: {(totalSum):f2} lv.");

        }
    }
}

using System;

namespace _1.GiftboxCoverageGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            int sheetsPaper = int.Parse(Console.ReadLine());
            double sheetArea = double.Parse(Console.ReadLine());

            double boxArea = 6 * sideA * sideA;
            double coveredArea = 0;

            for (int i = 1; i <= sheetsPaper; i++)
            {
                if (i % 3 == 0)
                {
                    coveredArea += sheetArea * 0.25;
                    continue;
                }

                coveredArea += sheetArea;
            }

            double percentage = coveredArea / boxArea * 100.0;
            if (sideA == 0)
            {
                percentage = 100;
            }

            if (sheetsPaper==0 || sheetArea==0)
            {
                percentage = 0;
            }
            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}

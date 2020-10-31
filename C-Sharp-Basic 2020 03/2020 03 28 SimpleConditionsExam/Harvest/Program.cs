using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            //read 
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int warkers = int.Parse(Console.ReadLine());

            //harvest x m2 - 40% for wine
            //1m2 = y kg grape
            //1l wine = 2.5kg grape

            double wine = x * 0.4 * y / 2.5;

            //neededWine = z
            double difference = (wine - z);
            double qtyPerWorker = (difference / warkers);

            if (wine < z)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(-difference)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(difference)} liters left -> { Math.Ceiling(qtyPerWorker) } liters per person.");
            }
        }
    }
}

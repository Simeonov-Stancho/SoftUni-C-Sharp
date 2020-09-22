using System;

namespace _01.BiscuitsFactoryGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            double biscuitsPerDay = int.Parse(Console.ReadLine());
            double workers = int.Parse(Console.ReadLine());
            double biscuitsForMonth = int.Parse(Console.ReadLine());

            double totalBiscuits = 0;
            double currentBiscuit = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    currentBiscuit = Math.Floor((biscuitsPerDay * workers) * 0.75);
                }

                else
                {
                    currentBiscuit = Math.Floor(biscuitsPerDay * workers);
                }

                totalBiscuits += currentBiscuit;
            }

            Console.WriteLine($"You have produced {totalBiscuits} biscuits for the past month.");

            if (totalBiscuits > biscuitsForMonth)
            {
                double percentage = (totalBiscuits - biscuitsForMonth) / biscuitsForMonth * 100;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }

            else
            {
                double percentage = (biscuitsForMonth - totalBiscuits) / biscuitsForMonth * 100;
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}

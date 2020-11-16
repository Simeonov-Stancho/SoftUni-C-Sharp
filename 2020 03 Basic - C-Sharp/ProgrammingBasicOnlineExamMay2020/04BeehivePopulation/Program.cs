using System;

namespace _04BeehivePopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPopulation = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());

            for (int i = 1; i <= years; i++)
            {
                int newBee = startingPopulation / 10 * 2;
                startingPopulation += newBee;

                if (i % 5 == 0)
                {
                    int migratedBee = startingPopulation / 50 * 5;
                    startingPopulation -= migratedBee;
                }
                int diedBee = startingPopulation / 20 * 2;
                startingPopulation -= diedBee;
            }

            Console.WriteLine($"Beehive population: {startingPopulation}");
        }
    }
}

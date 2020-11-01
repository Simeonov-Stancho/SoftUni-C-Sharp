using System;

namespace _1.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = int.Parse(Console.ReadLine());
            double plunder = int.Parse(Console.ReadLine());
            double expectedPlunder = int.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                double currentPlunder = plunder;
                if (i % 3 == 0)
                {
                    currentPlunder *= 1.5;
                }

                totalPlunder += currentPlunder;

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }

            else
            {
                double percentage = totalPlunder / expectedPlunder * 100.0;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}

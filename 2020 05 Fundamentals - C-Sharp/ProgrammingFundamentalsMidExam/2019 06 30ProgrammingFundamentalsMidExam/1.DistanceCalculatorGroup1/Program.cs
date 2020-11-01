using System;

namespace _1.DistanceCalculatorGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double stepLength = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            distance *= 100;

            double currentDistance = 0;

            for (int i = 1; i <= steps; i++)
            {
                if (i % 5 == 0)
                {
                    currentDistance += stepLength * 0.7;
                    continue;
                }

                currentDistance += stepLength;
            }



            double percentage = currentDistance / distance * 100.0;

            if (stepLength == 0)
            {
                percentage = 0;
            }

            else if (distance == 0)
            {
                percentage = 100;
            }

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}

using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double count = double.Parse(Console.ReadLine());
            double countNumberP1 = 0;
            double countNumberP2 = 0;
            double countNumberP3 = 0;

            for (int i = 1; i <= count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    countNumberP1 += 1;
                }
                if (number % 3 == 0)
                {
                    countNumberP2 += 1;
                }
                if (number % 4 == 0)
                {
                    countNumberP3 += 1;
                }

            }
            double countNumber = countNumberP1 + countNumberP2 + countNumberP3;
            Console.WriteLine($"{(countNumberP1 / count * 100):f2}%");
            Console.WriteLine($"{(countNumberP2 / count * 100):f2}%");
            Console.WriteLine($"{(countNumberP3 / count * 100):f2}%");
        }
    }
}

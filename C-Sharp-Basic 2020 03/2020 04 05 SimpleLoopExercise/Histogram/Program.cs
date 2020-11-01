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
            double countNumberP4 = 0;
            double countNumberP5 = 0;

            for (int i = 1; i <= count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                    countNumberP1 += 1;
                }
                else if (number >= 200 && number <= 399)
                {
                    countNumberP2 += 1;
                }
                else if (number >= 400 && number <= 599)
                {
                    countNumberP3 += 1;
                }
                else if (number >= 600 && number <= 799)
                {
                    countNumberP4 += 1;
                }
                else
                {
                    countNumberP5 += 1;
                }
            }
            double countNumber = countNumberP1 + countNumberP2 + countNumberP3 + countNumberP4 + countNumberP5;
            Console.WriteLine($"{(countNumberP1 / countNumber * 100):f2}%");
            Console.WriteLine($"{(countNumberP2 / countNumber * 100):f2}%");
            Console.WriteLine($"{(countNumberP3 / countNumber * 100):f2}%");
            Console.WriteLine($"{(countNumberP4 / countNumber * 100):f2}%");
            Console.WriteLine($"{(countNumberP5 / countNumber * 100):f2}%");

        }
    }
}

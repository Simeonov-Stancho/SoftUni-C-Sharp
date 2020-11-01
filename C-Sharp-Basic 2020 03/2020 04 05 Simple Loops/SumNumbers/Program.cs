using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                int y = int.Parse(Console.ReadLine());
                sum += y;
            }

            Console.WriteLine(sum);
        }
    }
}

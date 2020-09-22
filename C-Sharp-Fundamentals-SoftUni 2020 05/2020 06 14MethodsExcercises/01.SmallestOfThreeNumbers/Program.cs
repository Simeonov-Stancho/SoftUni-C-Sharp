using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LowestOfThreeNumbers
                    (int.Parse(Console.ReadLine()),
                     int.Parse(Console.ReadLine()),
                     int.Parse(Console.ReadLine())));
        }

        static int LowestOfThreeNumbers(int num1, int num2, int num3)
        {
            return Math.Min(num1, Math.Min(num2, num3));
        }
    }
}

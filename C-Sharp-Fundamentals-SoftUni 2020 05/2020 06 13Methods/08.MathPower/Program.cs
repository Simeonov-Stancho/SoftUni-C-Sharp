using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathPower
                                (double.Parse(Console.ReadLine()),
                                 int.Parse(Console.ReadLine())));
        }

        static double MathPower(double number, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}

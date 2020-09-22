using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int modulo = 0;

            while (number > 0)
            {
                modulo = number % 10;
                sum += modulo;
                number /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}

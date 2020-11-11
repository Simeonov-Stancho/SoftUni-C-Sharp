using System;

namespace _05AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int count = 0;
            double sum = 0;

            while (n > count)
            {
                double bankDeposit = double.Parse(Console.ReadLine());
                if (bankDeposit >= 0)
                {
                    Console.WriteLine($"Increase: {bankDeposit:f2}");
                    sum += bankDeposit;
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {sum:f2}");
        }

    }
}

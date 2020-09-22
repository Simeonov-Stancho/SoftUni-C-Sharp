using System;
using System.Threading;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int counter = 0;
            int currentAmount = 0;
            int totalAmount = 0;

            for (int i = startingYield; i >= 100; i -= 10)
            {
                currentAmount = i - 26;
                totalAmount += currentAmount;
                counter++;
            }

            if (totalAmount > 25)
            {
                totalAmount -= 26;
            }
            Console.WriteLine(counter);
            Console.WriteLine(totalAmount);
        }
    }
}

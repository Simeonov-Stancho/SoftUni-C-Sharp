using System;

namespace _03SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "Stop")
            {
                int currentNumber = int.Parse(input);
                sum += currentNumber;
                input = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}

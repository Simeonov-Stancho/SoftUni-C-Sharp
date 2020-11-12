using System;

namespace _03SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (command != "stop")
            {
                int number = int.Parse(command);

                if (number<0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                if (IsPrime(number))
                {
                    primeSum += number;
                }

                else
                {
                    nonPrimeSum += number;
                }
                command = Console.ReadLine();

                if (command == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
                    Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
                    return;
                }
            }
        }
        static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

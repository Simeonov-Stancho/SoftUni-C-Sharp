using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currentNumber = 2; currentNumber <= number; currentNumber++)
            {
                string isPrime = "true";

                for (int cepitel = 2; cepitel < currentNumber; cepitel++)
                {
                    if (currentNumber % cepitel == 0)
                    {
                        isPrime = "false";
                    }
                }

                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }
        }
    }
}


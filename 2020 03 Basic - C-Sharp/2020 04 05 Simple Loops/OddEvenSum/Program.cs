using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumber = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < countNumber; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += currNum;
                }
                else
                {
                    oddSum += currNum;
                }


            }

            if (oddSum == evenSum)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {oddSum}");
            }
            else
            {
                int diff = 0;
                if (oddSum > evenSum)
                {
                    diff = oddSum - evenSum;
                }

                else
                {
                    diff = evenSum - oddSum;
                }
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}


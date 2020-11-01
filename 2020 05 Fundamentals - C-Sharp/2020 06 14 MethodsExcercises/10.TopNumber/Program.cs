using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfTheDigit = DigitSum(i);

                if (DivisibleByEight(sumOfTheDigit) && CheckForOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int DigitSum(int num)
        {
            int numbersSum = 0;
            string number = num.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                numbersSum += number[i] - 48;
            }

            return numbersSum;
        }

        static bool DivisibleByEight(int num)
        {
            bool isDivisible = false;

            if (num % 8 == 0)
            {
                isDivisible = true;
            }

            return isDivisible;
        }

        static bool CheckForOddDigit(int num)
        {
            bool isOdd = false;
            string number = num.ToString();
            int currentDigit = 0;

            for (int i = 0; i < number.Length; i++)
            {
                currentDigit = number[i] - 48;

                if (currentDigit % 2 != 0)
                {
                    isOdd = true;
                    break;
                }
            }

            return isOdd;
        }
    }
}
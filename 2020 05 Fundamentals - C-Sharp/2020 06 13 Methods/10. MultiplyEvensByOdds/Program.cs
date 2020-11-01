using System;
using System.Linq;

namespace _10._MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);

            //Console.WriteLine(OddSum(n) * EvenSum(n));
            
            Console.WriteLine(OddSumFast(n) * EvenSumFast(n));
        }

        static int OddSum(int input)
        {
            int oddSum = 0;

            while (input > 0)
            {
                int num = input % 10;
                if (num % 2 != 0)
                {
                    oddSum += num;
                }

                input = input / 10;
            }

            return oddSum;
        }

        static int EvenSum(int input)
        {
            int evenSum = 0;

            while (input > 0)
            {
                int num = input % 10;
                if (num % 2 == 0)
                {
                    evenSum += num;
                }

                input = input / 10;
            }

            return evenSum;
        }



        static int OddSumFast(int input)
        {
            int oddSum = 0;
            string number = input.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == 1)
                {
                    oddSum += currentDigit;
                }
            }
            return oddSum;
        }

        static int EvenSumFast(int input)
        {
            int evenSum = 0;
            string number = input.ToString();

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
            }
            return evenSum;
        }

    }
}

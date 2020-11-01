using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 2 == 0)
                {
                    sumEven += number[i];
                }

                else
                {
                    sumOdd += number[i];
                }
            }

            Console.WriteLine(sumEven - sumOdd);
        }
    }
}

using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersRowOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbersRowTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isEqual = false;
            int sum = 0;
            int differentIndex = 0;

            for (int i = 0; i < numbersRowOne.Length; i++)
            {
                if (numbersRowOne[i] == numbersRowTwo[i])
                {
                    isEqual = true;
                    sum += numbersRowOne[i];
                }

                else
                {
                    differentIndex = i;
                    isEqual = false;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {differentIndex} index");
            }
        }
    }
}

using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = ArraySum(array, 0);
            Console.WriteLine(sum);
        }

        static int ArraySum(int[] array, int index)
        {
            if (index == array.Length-1)
            {
                return array[index];
            }

            return array[index] + ArraySum(array, index + 1);
        }
    }
}

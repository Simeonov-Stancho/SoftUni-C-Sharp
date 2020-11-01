using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 0;
            int lenght = 1;
            int num = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    lenght++;
                }

                else
                {
                    lenght = 1;
                }

                if (lenght > count)
                {
                    count = lenght;
                    num = numbers[i];
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{num} ");
            }
        }
    }
}

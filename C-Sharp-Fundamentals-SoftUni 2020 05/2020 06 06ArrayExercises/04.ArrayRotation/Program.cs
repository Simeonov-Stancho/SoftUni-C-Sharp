using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            //for (int i = 0; i < num; i++)
            //{
            //    int[] temp = new int[numbers.Length];
            //    int firstDigit = numbers[0];

            //    for (int j = 0; j < numbers.Length - 1; j++)
            //    {
            //        temp[j] = numbers[j + 1];
            //    }

            //    temp[temp.Length - 1] = firstDigit;
            //    numbers = temp;
            //}

            //Console.WriteLine(string.Join(" ", numbers));


            for (int j = 0; j < num; j++)
            {
                int firstDigit = numbers[0];
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[i + 1];
                }
                numbers[numbers.Length - 1] = firstDigit;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
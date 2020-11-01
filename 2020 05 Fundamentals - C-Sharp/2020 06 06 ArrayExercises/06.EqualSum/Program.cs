using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumLeft = 0;
            int sumRight = numbers.Sum();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                sumRight -= numbers[i];

                if (sumRight == sumLeft)
                {
                    Console.WriteLine(i);
                    return;
                }

                sumLeft += numbers[i];
            }

            Console.WriteLine("no");


            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int sumLeft = 0;
            //int sumRight = 0;
            //bool isEqual = false;

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (i == 0)
            //    {
            //        sumLeft = 0;
            //    }

            //    else
            //    {
            //        sumLeft += numbers[i - 1];
            //    }

            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        sumRight += numbers[j];
            //    }

            //    if (sumLeft == sumRight)
            //    {
            //        Console.WriteLine(i);
            //        isEqual = true;
            //        break;
            //    }

            //    else
            //    {
            //        sumRight = 0;
            //    }
            //}

            //if (isEqual != true)
            //{
            //    Console.WriteLine("no");
            //}
        }
    }
}
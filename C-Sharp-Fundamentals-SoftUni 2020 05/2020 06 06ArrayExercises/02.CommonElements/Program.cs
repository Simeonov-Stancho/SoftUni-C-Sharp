using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            //for (int i = 0; i < secondArray.Length; i++)
            //{
            //    for (int j = 0; j < firstArray.Length; j++)
            //    {
            //        if (secondArray[i] == firstArray[j])
            //        {
            //            Console.Write($"{secondArray[i]} ");
            //        }
            //    }
            //}

            //foreach (var secondArrayItems in secondArray)
            //{
            //    foreach (var firstArrayItems in firstArray)
            //    {
            //        if (secondArrayItems == firstArrayItems)
            //        {
            //            Console.Write($"{secondArrayItems} ");
            //        }
            //    }
            //}

            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray.Contains(secondArray[i]))
                {
                    Console.Write($"{secondArray[i]} ");
                }
            }
        }
    }
}

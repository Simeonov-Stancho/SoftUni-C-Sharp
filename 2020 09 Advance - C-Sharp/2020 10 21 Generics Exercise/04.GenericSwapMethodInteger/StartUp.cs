using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> data = new List<int>();

            for (int i = 0; i < n; i++)
            {
                data.Add(int.Parse(Console.ReadLine()));
            }

            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Box<int> box = new Box<int>(data);
            box.SwapElements(array[0], array[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
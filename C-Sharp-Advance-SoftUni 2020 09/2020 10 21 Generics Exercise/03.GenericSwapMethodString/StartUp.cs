using GenericBoxOfInteger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> data = new List<string>();

            for (int i = 0; i < n; i++)
            {
                data.Add(Console.ReadLine());
            }

            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Box<string> box = new Box<string>(data);
            box.SwapElements(array[0], array[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
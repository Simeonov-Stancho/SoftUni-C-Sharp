using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] value = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(value);
            int racks = 1;
            int sum = 0;

            if (capacity == 0)
            {
                Console.WriteLine(0);
                return;
            }

            foreach (int price in stack)
            {
                if ((sum + price) <= capacity)
                {
                    sum += price;
                }

                else
                {
                    racks++;
                    sum = price;
                }
            }

            Console.WriteLine(racks);
        }
    }
}

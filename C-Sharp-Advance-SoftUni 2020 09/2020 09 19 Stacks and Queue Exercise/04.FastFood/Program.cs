using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(array);

            Console.WriteLine(orders.Max());

            if (quantity == 0)
            {
                PrintOrdersLeft(orders);
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (orders.Peek() <= quantity)
                {
                    quantity -= orders.Dequeue();
                }

                else
                {
                    PrintOrdersLeft(orders);
                    return;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }


        }

        static void PrintOrdersLeft(Queue<int> orders)
        {
            Console.Write("Orders left: ");
            Console.WriteLine(string.Join(" ", orders));
        }
    }
}

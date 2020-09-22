using System;
using System.Collections;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    PaidCustomer(queue);
                }

                else
                {
                    AddCustomer(queue, input);
                }

            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }

        static void PaidCustomer(Queue<string> queue)
        {
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        static void AddCustomer(Queue<string> queue, string input)
        {
            queue.Enqueue(input);
        }
    }
}

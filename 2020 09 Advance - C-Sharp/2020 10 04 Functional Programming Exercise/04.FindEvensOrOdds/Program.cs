using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Predicate<int> predicate = num => num % 2 == 0;
            List<int> numbers = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (command == "odd" && !predicate(i))
                {
                    numbers.Add(i);
                }

                else if (command == "even" && predicate(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

            //other solution:
            // int a = 5;
            // int b = a > 3 ? a : 10
            // where ? if true b= a,  : or false = 10

            //Predicate<int> predicate = command == "odd" ?
            //    new Predicate<int>(n => n % 2 != 0) : new
            //    Predicate<int>(n => n % 2 == 0);

            //for (int i = bounds[0]; i <= bounds[1]; i++)
            //{
            //    if (predicate(i))
            //    {
            //        numbers.Add(i);
            //    }
            //}
        }
    }
}
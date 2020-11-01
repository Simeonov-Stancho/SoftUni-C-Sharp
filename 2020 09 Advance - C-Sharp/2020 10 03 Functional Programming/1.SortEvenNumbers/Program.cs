using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var evenNum = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Where(n => n % 2 == 0)
                            .OrderBy(n => n);

            Console.Write(string.Join(", ", evenNum));
        }
    }
}
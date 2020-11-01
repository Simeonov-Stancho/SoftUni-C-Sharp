using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .Reverse()
                                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<int, int, bool> noDevisible = (a, b) => a % b != 0;

            numbers = numbers.Where(x => noDevisible(x, divider)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
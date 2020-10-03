using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> intFunc = int.Parse;

            var numbers = Console.ReadLine()
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(intFunc);

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
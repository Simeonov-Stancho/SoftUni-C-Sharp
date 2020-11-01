using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            Func<string, int, bool> isEqualOrLarger =
                (name, n) => name.Sum(x => x) >= n;

            Func<List<string>, int, Func<string, int, bool>, string> checkNames =
                (name, n, isEqualOrLarger) =>
                name.FirstOrDefault(name => isEqualOrLarger(name, n));

            Console.WriteLine(checkNames(names, n, isEqualOrLarger));
        }
    }
}
using System;
using System.Linq;

namespace _4.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .Select(p => p * 1.2)
                    .Select(p => $"{p:f2}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }
    }
}
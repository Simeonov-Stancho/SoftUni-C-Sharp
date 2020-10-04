using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(name => Console.WriteLine(name)));
        }
    }
}

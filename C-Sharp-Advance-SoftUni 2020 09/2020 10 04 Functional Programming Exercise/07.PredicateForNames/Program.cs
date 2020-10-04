using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> array = Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                           .ToList();

            Func<string, bool> checkLength = x => x.Length <= nameLength;
            array = array.Where(x => checkLength(x)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, array));

            //second solution
            //Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  //.Where(checkLength)
                  //.ToList()
                 // .ForEach(Console.WriteLine);
        }
    }
}
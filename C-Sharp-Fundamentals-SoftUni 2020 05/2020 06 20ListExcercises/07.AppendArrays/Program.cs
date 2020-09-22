using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                     .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();
            input.Reverse();
            List<string> printList = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                string word = input[i];
                List<string> newList = word
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

                printList.AddRange(newList);
            }

            Console.WriteLine(string.Join(" ", printList));
        }
    }
}
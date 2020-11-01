using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = ReadList();
            List<int> result = Result(input);

            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> Result(List<int> input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Count / 2; i++)
            {
                result.Add(input[i] + input[input.Count - i - 1]);
            }

            if (input.Count % 2 != 0)
            {
                result.Add(input[input.Count / 2]);
            }

            return result;
        }

        static List<int> ReadList()
        {
            List<int> readList = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();
            return readList;
        }
    }
}
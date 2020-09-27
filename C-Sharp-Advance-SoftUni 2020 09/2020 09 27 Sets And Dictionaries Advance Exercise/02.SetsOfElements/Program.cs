using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int n = array[0];
            int m = array[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> uniquedSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                firstSet.Add(currentNum);
            }

            for (int i = 0; i < m; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                secondSet.Add(currentNum);
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    uniquedSet.Add(num);
                }
            }
            Console.WriteLine(string.Join(" ", uniquedSet));
        }
    }
}

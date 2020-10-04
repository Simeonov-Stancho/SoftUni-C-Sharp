using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
         {
            Func<int, int, int> comparator = new Func<int, int, int>((a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }

                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }

                else
                {
                    return a.CompareTo(b);
                }
            });

            Comparison<int> comparison = new Comparison<int>(comparator);

            int[] array = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Array.Sort(array, comparison);
            Console.WriteLine(string.Join(" ", array));
        }
    }
}

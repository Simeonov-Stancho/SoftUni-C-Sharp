using System;
using System.Linq;

namespace _03.Zig_ZagArrays100
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];


            for (int i = 0; i < n; i++)
            {
                int[] lines = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = lines[0];
                    secondArray[i] = lines[1];
                    continue;
                }

                else
                {
                    firstArray[i] = lines[1];
                    secondArray[i] = lines[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}

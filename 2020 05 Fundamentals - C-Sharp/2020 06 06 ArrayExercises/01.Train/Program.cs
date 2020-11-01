using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] wagonPeople = new int[n];

            for (int i = 0; i < n; i++)
            {
                wagonPeople[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", wagonPeople));
            Console.WriteLine(wagonPeople.Sum());

        }
    }
}

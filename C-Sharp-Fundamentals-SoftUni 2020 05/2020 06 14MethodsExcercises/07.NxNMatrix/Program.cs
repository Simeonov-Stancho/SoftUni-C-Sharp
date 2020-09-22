using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                PrintNxN( number);
                Console.WriteLine();
            }
        }

        static void PrintNxN (int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{n} ");
            }
        }
    }
}

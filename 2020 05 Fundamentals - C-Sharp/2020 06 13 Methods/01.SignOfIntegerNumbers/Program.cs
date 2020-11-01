using System;

namespace TestMehod
{
    class Program
    {
        static void Main(string[] args)
        {
            SignOfNumber(int.Parse(Console.ReadLine()));
        }

        static void SignOfNumber(int first)
        {
            if (first > 0)
            {
                Console.WriteLine($"The number {first} is positive.");
            }

            else if (first == 0)
            {
                Console.WriteLine($"The number {first} is zero.");
            }

            else
            {
                Console.WriteLine($"The number {first} is negative.");
            }
        }
    }
}
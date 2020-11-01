using System;

namespace _04._SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char charachter = char.Parse(Console.ReadLine());
                sum += charachter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

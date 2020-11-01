using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int newNumber = i;
                int sum = 0;
                bool isSpecial = false;

                while (newNumber > 0)
                {
                    sum += newNumber % 10;
                    newNumber /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}

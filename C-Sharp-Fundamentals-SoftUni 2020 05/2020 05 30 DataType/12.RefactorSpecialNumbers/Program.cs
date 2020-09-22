using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int modulatedNumber = i;
                int sum = 0;
                bool isSpecial = false;

                while (modulatedNumber > 0)
                {
                    sum += modulatedNumber % 10;
                    modulatedNumber /= 10;
                }

                if ((sum == 5) || (sum == 7) || (sum == 11))
                {
                    isSpecial = true;
                }

                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }

        }
    }
}

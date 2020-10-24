using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factoriel(n));
        }

        public static int Factoriel(int n)
        {
            if (n==1)
            {
                return 1;
            }

            return n * Factoriel(n - 1);
        }
    }
}
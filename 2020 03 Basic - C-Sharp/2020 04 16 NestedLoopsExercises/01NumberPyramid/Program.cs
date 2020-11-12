using System;

namespace _01NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(global::System.Console.ReadLine());
            int currentNum = 1;
            bool stop = false;

            for (int i = 1; i <= n; i++)
            {

                for (int x = 1; x <= i; x++)
                {
                    if (currentNum > n)
                    {
                        stop = true;
                        break;
                    }
                    Console.Write($"{ currentNum } ");
                    currentNum++;
                }

                if (stop)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}

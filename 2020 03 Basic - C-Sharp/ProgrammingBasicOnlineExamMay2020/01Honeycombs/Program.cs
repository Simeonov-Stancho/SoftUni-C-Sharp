using System;

namespace _01Honeycombs
{
    class Program
    {
        static void Main(string[] args)
        {
            double bee = int.Parse(Console.ReadLine());
            double flowers = int.Parse(Console.ReadLine());

            double honey = bee * flowers * 0.21;
            double honeyDisks = honey / 100.0;

            Console.WriteLine($"{Math.Floor(honeyDisks)} honeycombs filled.");
            Console.WriteLine($"{(honey - (Math.Floor(honeyDisks) * 100)):f2} grams of honey left.");
        }
    }
}

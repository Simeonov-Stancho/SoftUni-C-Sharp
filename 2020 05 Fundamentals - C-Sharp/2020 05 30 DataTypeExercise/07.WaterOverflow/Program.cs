using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            short capacity = 0;

            for (short i = 0; i < n; i++)
            {
                short quantities = short.Parse(Console.ReadLine());
                capacity += quantities;

                if (capacity > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    capacity -= quantities;
                }
            }
            Console.WriteLine(capacity);
        }
    }
}

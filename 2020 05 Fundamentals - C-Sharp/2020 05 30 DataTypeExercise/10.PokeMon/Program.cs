using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            uint power = uint.Parse(Console.ReadLine());
            uint distance = uint.Parse(Console.ReadLine());
            byte exhaustionFactor = byte.Parse(Console.ReadLine());

            uint counter = 0;
            uint currentPower = power;

            while (currentPower >= distance)
            {
                counter++;
                currentPower -= distance;

                if (power / 2 == currentPower && exhaustionFactor!=0)
                {
                    currentPower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currentPower);
            Console.WriteLine(counter);
        }
    }
}

using System;

namespace _05BeehiveDefense
{
    class Program
    {
        static void Main(string[] args)
        {
            double beeCount = double.Parse(Console.ReadLine());
            double bearHealth = double.Parse(Console.ReadLine());
            double attack = double.Parse(Console.ReadLine());

            while (true)
            {
                beeCount -= attack;
                bearHealth = bearHealth - (beeCount * 5);

                if (beeCount < 100)
                {
                    if (beeCount < 0)
                    {
                        Console.WriteLine($"The bear stole the honey! Bees left 0.");
                        return;
                    }
                    Console.WriteLine($"The bear stole the honey! Bees left {beeCount}.");
                    break;
                }

                if (bearHealth <= 0)
                {
                    Console.WriteLine($"Beehive won! Bees left {beeCount}.");
                    break;
                }
            }
        }
    }
}

using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int winGames = 0;

            while (command != "End of battle" || energy < 0)
            {
                int distance = int.Parse(command);

                if (energy >= distance)
                {
                    winGames++;
                    energy -= distance;

                    if (winGames % 3 == 0)
                    {
                        energy += winGames;
                    }
                }

                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winGames} won battles and {energy} energy");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {winGames}. Energy left: {energy}");
        }
    }
}

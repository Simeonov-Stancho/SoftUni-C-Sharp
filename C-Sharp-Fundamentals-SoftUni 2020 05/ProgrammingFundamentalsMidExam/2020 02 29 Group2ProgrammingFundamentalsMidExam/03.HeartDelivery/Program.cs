using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                            .Split('@', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            string jump = string.Empty;
            int currentHouse = 0;

            while ((jump = Console.ReadLine()) != "Love!")
            {
                List<string> command = jump
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();


                int length = int.Parse(command[1]);
                currentHouse += length;

                if (currentHouse >= neighborhood.Count)
                {
                    currentHouse = 0;
                }

                if (neighborhood[currentHouse] == 0)
                {
                    Console.WriteLine($"Place {currentHouse} already had Valentine's day.");
                }

                else
                {
                    neighborhood[currentHouse] -= 2;

                    if (neighborhood[currentHouse] == 0)
                    {
                        Console.WriteLine($"Place {currentHouse} has Valentine's day.");
                    }
                }

            }

            Console.WriteLine($"Cupid's last position was {currentHouse}.");

            int houseCount = 0;

            for (int i = 0; i < neighborhood.Count; i++)
            {
                if (neighborhood[i] != 0)
                {
                    houseCount++;
                }
            }

            if (houseCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }

            else
            {
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
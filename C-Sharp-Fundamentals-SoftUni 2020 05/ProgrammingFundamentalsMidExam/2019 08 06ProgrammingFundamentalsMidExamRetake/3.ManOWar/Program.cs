using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> statusPirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> statusWarShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Retire")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Fire")
                {
                    Attacks(statusWarShip, commands);

                    if (statusWarShip.Contains(0))
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }

                else if (commands[0] == "Defend")
                {
                    Defend(statusPirateShip, commands);

                    if (statusPirateShip.Contains(0))
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        return;
                    }
                }

                else if (commands[0] == "Repair")
                {
                    Repair(statusPirateShip, commands, maxHealth);
                }

                else if (commands[0] == "Status")
                {
                    Console.WriteLine($"{ShipStatus(statusPirateShip, commands, maxHealth)} sections need repair.");
                }
            }

            int pirateShipSum = statusPirateShip.Sum();
            int warshipSum = statusWarShip.Sum();

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warshipSum}");
        }

        static List<int> Attacks(List<int> statusWarShip, List<string> commands)
        {
            int index = int.Parse(commands[1]);
            int damage = int.Parse(commands[2]);

            if (index >= 0 && index < statusWarShip.Count)
            {
                statusWarShip[index] -= damage;
                if (statusWarShip[index] < 0)
                {
                    statusWarShip[index] = 0;
                }
            }

            return statusWarShip;
        }

        static List<int> Defend(List<int> statusPirateShip, List<string> commands)
        {
            int startIndex = int.Parse(commands[1]);
            int endIndex = int.Parse(commands[2]);
            int damage = int.Parse(commands[3]);

            if (startIndex >= 0 && endIndex >= 0
                && startIndex < statusPirateShip.Count && endIndex < statusPirateShip.Count)
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    statusPirateShip[i] -= damage;
                    if (statusPirateShip[i] < 0)
                    {
                        statusPirateShip[i] = 0;
                    }
                }
            }

            return statusPirateShip;
        }

        static List<int> Repair(List<int> statusPirateShip, List<string> commands, int maxHealth)
        {
            int index = int.Parse(commands[1]);
            int health = int.Parse(commands[2]);

            if (index >= 0 && index < statusPirateShip.Count)
            {
                statusPirateShip[index] += health;

                if (statusPirateShip[index] > maxHealth)
                {
                    statusPirateShip[index] = maxHealth;
                }
            }

            return statusPirateShip;
        }

        static int ShipStatus(List<int> statusPirateShip, List<string> commands, int maxHealth)
        {
            int count = 0;

            for (int i = 0; i < statusPirateShip.Count; i++)
            {
                if (statusPirateShip[i] < (0.2 * maxHealth))
                {
                    count++;
                }
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            List<string> rooms = Console.ReadLine()
                            .Split('|', StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            int roomCount = 0;

            for (int i = 0; i < rooms.Count; i++)
            {
                roomCount++;
                string currentRoom = rooms[i];
                List<string> command = currentRoom
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[0] == "potion")
                {
                    int amount = int.Parse(command[1]);
                    health += amount;

                    if (health > 100)
                    {
                        amount = 100 - health + amount;
                        health = 100;
                    }

                    Console.WriteLine($"You healed for {amount} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (command[0] == "chest")
                {
                    int amount = int.Parse(command[1]);
                    bitcoins += amount;

                    Console.WriteLine($"You found {amount} bitcoins.");
                }

                else
                {
                    int attack = int.Parse(command[1]);

                    health -= attack;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command[0]}.");
                    }

                    else
                    {
                        Console.WriteLine($"You died! Killed by {command[0]}.");
                        Console.WriteLine($"Best room: {roomCount}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}

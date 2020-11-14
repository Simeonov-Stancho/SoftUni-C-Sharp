using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            double price = 0;
            double costs = 0;

            while (command != "Game Time")
            {
                switch (command)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;

                    case "CS: OG":
                        price = 15.99;
                        break;

                    case "Zplinter Zell":
                        price = 19.99;
                        break;

                    case "Honored 2":
                        price = 59.99;
                        break;

                    case "RoverWatch":
                        price = 29.99;
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        command = Console.ReadLine();
                        continue;
                }

                costs += price;

                if (costs == budget)
                {
                    Console.WriteLine($"Bought {command}");
                    Console.WriteLine("Out of money!");
                    return;
                }

                else if (budget < costs)
                {
                    Console.WriteLine("Too Expensive");
                    costs -= price;
                }

                else
                {
                    Console.WriteLine($"Bought {command}");
                }

                command = Console.ReadLine();
            }

            if (command == "Game Time")
            {
                Console.WriteLine($"Total spent: ${costs:f2}. Remaining: ${(budget - costs):f2}");
            }
        }
    }
}

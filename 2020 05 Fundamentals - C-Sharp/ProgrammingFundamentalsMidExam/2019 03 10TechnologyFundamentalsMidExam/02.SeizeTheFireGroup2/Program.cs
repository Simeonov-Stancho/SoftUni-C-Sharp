using System;
using System.Linq;

namespace _02.SeizeTheFireGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fire = Console.ReadLine()
                .Split("#", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            double totalFire = 0;

            Console.WriteLine("Cells:");

            for (int i = 0; i < fire.Length; i++)
            {
                string[] currentFire = fire[i]
                .Split(" = ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (currentFire[0] == "High")
                {
                    int value = int.Parse(currentFire[1]);

                    if (value >= 81 && value <= 125)
                    {
                        if (value > water)
                        {
                            continue;
                        }
                        water -= value;
                        effort += 0.25 * value;
                        totalFire += value;
                        Console.WriteLine($"- {currentFire[1]}");
                    }

                }

                else if (currentFire[0] == "Medium")
                {
                    int value = int.Parse(currentFire[1]);

                    if (value >= 51 && value <= 80)
                    {
                        if (value > water)
                        {
                            continue;
                        }
                        water -= value;
                        effort += 0.25 * value;
                        totalFire += value;
                        Console.WriteLine($"- {currentFire[1]}");
                    }
                }

                else if (currentFire[0] == "Low")
                {
                    int value = int.Parse(currentFire[1]);

                    if (value >= 1 && value <= 50)
                    {
                        if (value > water)
                        {
                            continue;
                        }
                        water -= value;
                        effort += 0.25 * value;
                        totalFire += value;
                        Console.WriteLine($"- {currentFire[1]}");
                    }
                }
            }

            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}

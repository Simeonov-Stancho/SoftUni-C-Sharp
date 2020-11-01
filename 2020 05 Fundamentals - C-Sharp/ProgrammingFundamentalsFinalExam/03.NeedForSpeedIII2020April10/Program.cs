using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII2020April10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carsInformation = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<string> cars = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string car = cars[0];
                int mileage = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);

                carsInformation.Add(car, new List<int>());
                carsInformation[car].Add(mileage);
                carsInformation[car].Add(fuel);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                List<string> command = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "Drive")
                {
                    if (carsInformation.ContainsKey(command[1]))
                    {
                        int currentFuel = carsInformation[command[1]][1];
                        int neededFuel = int.Parse(command[3]);
                        if (currentFuel < neededFuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                            continue;
                        }

                        carsInformation[command[1]][1] -= neededFuel;
                        carsInformation[command[1]][0] += int.Parse(command[2]);
                        Console.WriteLine($"{command[1]} driven for {command[2]} kilometers. {command[3]} liters of fuel consumed.");

                        if (carsInformation[command[1]][0] >= 100000)
                        {
                            carsInformation.Remove(command[1]); 
                            Console.WriteLine($"Time to sell the {command[1]}!");
                        }
                    }
                }

                else if (command[0] == "Refuel")
                {
                    int currentFuel = carsInformation[command[1]][1];

                    if ((currentFuel + int.Parse(command[2]) > 75))
                    {
                        int refueledFuel = 75 - currentFuel;
                        carsInformation[command[1]][1] = 75;
                        Console.WriteLine($"{command[1]} refueled with {refueledFuel} liters");
                        continue;
                    }

                    carsInformation[command[1]][1] += int.Parse(command[2]);
                    Console.WriteLine($"{command[1]} refueled with {int.Parse(command[2])} liters");
                }

                else if (command[0] == "Revert")
                {
                    int currentMileage = carsInformation[command[1]][0];

                    if (currentMileage - int.Parse(command[2]) < 10000)
                    {
                        carsInformation[command[1]][0] = 10000;
                        continue;
                    }

                    carsInformation[command[1]][0] -= int.Parse(command[2]);
                    Console.WriteLine($"{command[1]} mileage decreased by {int.Parse(command[2])} kilometers");
                }
            }

            carsInformation = carsInformation
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var cars in carsInformation)
            {
                string car = cars.Key;
                int mileage = cars.Value[0];
                int fuel = cars.Value[1];

                Console.WriteLine($"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}

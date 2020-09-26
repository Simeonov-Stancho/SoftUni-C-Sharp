using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> cars = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string direction = command[0];
                string carNumber = command[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }

                else if (direction == "OUT")
                {
                    if (cars.Contains(carNumber))
                    {
                        cars.Remove(carNumber);
                    }
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            else
            {
                foreach (var carNum in cars)
                {
                    Console.WriteLine(carNum);
                }
            }
        }
    }
}

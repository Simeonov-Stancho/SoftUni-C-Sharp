using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPassCar = int.Parse(Console.ReadLine());
            string input = string.Empty;
            Queue<string> cars = new Queue<string>();

            int totalPassedCars = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 1; i <= numberPassCar; i++)
                    {
                        if (cars.Count <= 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        totalPassedCars++;

                    }
                    continue;
                }

                cars.Enqueue(input);
            }

            Console.WriteLine($"{totalPassedCars} cars passed the crossroads.");
        }
    }
}

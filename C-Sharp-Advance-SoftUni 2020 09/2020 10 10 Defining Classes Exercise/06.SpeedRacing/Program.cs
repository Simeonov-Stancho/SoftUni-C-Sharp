using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            AddCars(n, cars);

            DriveCars(cars);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

        private static void AddCars(int n, List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }
        }

        private static string DriveCars(List<Car> cars)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                string carModel = command[1];
                double amountOfKm = double.Parse(command[2]);

                Car currentCar = cars.Find(x => x.Model == carModel);
                currentCar.Calculate(currentCar, amountOfKm);
            }

            return input;
        }
    }
}

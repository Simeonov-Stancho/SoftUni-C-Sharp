using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            AddCars(n, cars);

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    bool isTrue = false;
                    foreach (var tire in car.Tire)
                    {
                        if (tire.TirePressure < 1)
                        {
                            isTrue = true;
                        }
                    }

                    if (isTrue && car.Cargo.CargoType == "fragile")
                    {
                        Console.WriteLine(car.Model);
                    }
                }

                //also can be func:
                //List<Car> matchingCar = cars
                //    .Where(c => c.Cargo.CargoType == "fragile" &&
                //              c.Tire.Any(t => t.TirePressure < 1))
                //              .ToList();
                // PrintMatchingCar(matchingCar);
            }

            else if (command == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }

        private static void PrintMatchingCar(List<Car> matchingCar)
        {
            foreach (var car in matchingCar)
            {
                Console.WriteLine(car.Model);
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
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                Engine currentEngine = new Engine(engineSpeed, enginePower);
                Cargo currentCargo = new Cargo(cargoWeight, cargoType);
                Tire[] currentTires = new Tire[4]
                {
                    new Tire (tire1Pressure,tire1Age),
                    new Tire (tire2Pressure,tire2Age),
                    new Tire (tire3Pressure,tire3Age),
                    new Tire (tire4Pressure,tire4Age),
                };

                Car currentCar = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(currentCar);
            }
        }
    }
}

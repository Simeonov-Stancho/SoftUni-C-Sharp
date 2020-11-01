using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            AddEngine(n, engines);

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            AddCar(m, cars, engines);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            static void AddEngine(int n, List<Engine> engines)
            {
                for (int i = 0; i < n; i++)
                {
                    string[] engineInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string engineModel = engineInfo[0];
                    int enginePower = int.Parse(engineInfo[1]);
                    Engine currentEngine = new Engine(engineModel, enginePower);

                    if (engineInfo.Length == 3 && char.IsDigit(engineInfo[2][0]))
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        currentEngine = new Engine(engineModel, enginePower, displacement);
                    }

                    else if (engineInfo.Length == 3 && char.IsLetter(engineInfo[2][0]))
                    {
                        string efficiency = engineInfo[2];
                        currentEngine = new Engine(engineModel, enginePower, efficiency);
                    }

                    else if (engineInfo.Length == 4)
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        string efficiency = engineInfo[3];
                        currentEngine = new Engine(engineModel, enginePower, displacement, efficiency);
                    }

                    engines.Add(currentEngine);
                }
            }

            static void AddCar(int m, List<Car> cars, List<Engine> engines)
            {
                for (int i = 0; i < m; i++)
                {
                    string[] carInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string carModel = carInfo[0];
                    string engineModel = carInfo[1];
                    Engine currentEngine = new Engine();

                    foreach (var engine in engines)
                    {
                        if (engine.Model == engineModel)
                        {
                            currentEngine = engine;
                        }
                    }

                    Car currentCar = new Car(carModel, currentEngine);

                    if (carInfo.Length == 3 && char.IsDigit(carInfo[2][0]))
                    {
                        int weight = int.Parse(carInfo[2]);
                        currentCar = new Car(carModel, currentEngine, weight);
                    }

                    else if (carInfo.Length == 3 && char.IsLetter(carInfo[2][0]))
                    {
                        string color = carInfo[2];
                        currentCar = new Car(carModel, currentEngine, color);
                    }

                    else if (carInfo.Length == 4)
                    {
                        int weight = int.Parse(carInfo[2]);
                        string color = carInfo[3];
                        currentCar = new Car(carModel, currentEngine, weight, color);
                    }

                    cars.Add(currentCar);
                }
            }
        }
    }
}

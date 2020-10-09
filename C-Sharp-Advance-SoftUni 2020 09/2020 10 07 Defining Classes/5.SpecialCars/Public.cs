using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialCars
{
    public class Public
    {
        static void Main(string[] args)
        {
            string input;

            List<Tire[]> tires = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                tires = GetTires(input, tires);
            }

            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                engines = GetEngines(input, engines);
            }

            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                cars = GetCar(input, cars, engines, tires);
            }

            FindSpecialCar(cars);
        }

        static List<Tire[]> GetTires(string input, List<Tire[]> tires)
        {
            string[] tyreArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Tire[] currentTire = new Tire[4];
            int tyreCount = 0;

            for (int i = 0; i < tyreArray.Length; i += 2)
            {
                int year = int.Parse(tyreArray[i]);
                double pressure = double.Parse(tyreArray[i + 1]);
                
                currentTire[tyreCount] = new Tire(year, pressure);
                tyreCount++;
            }

            tires.Add(currentTire);

            return tires;
        }

        public static List<Engine> GetEngines(string input, List<Engine> engines)
        {
            string[] enginData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int horsePower = int.Parse(enginData[0]);
            double cubicCapacity = double.Parse(enginData[1]);
            
            engines.Add(new Engine(horsePower, cubicCapacity));

            return engines;
        }

        public static List<Car> GetCar(string input, List<Car> cars, List<Engine> engines, List<Tire[]> tires)
        {
            string[] carData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string make = carData[0];
            string model = carData[1];
            int year = int.Parse(carData[2]);
            double fuelQuantity = double.Parse(carData[3]);
            double fuelConsumption = double.Parse(carData[4]);
            int engineIndex = int.Parse(carData[5]);
            int tiresIndex = int.Parse(carData[6]);

            cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption,
                engines[engineIndex], tires[tiresIndex]));

            return cars;
        }

        public static void FindSpecialCar(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Car currentCar = cars[i];
                double allTirePressures = 0;

                for (int j = 0; j < currentCar.Tires.Length; j++)
                {
                    allTirePressures += currentCar.Tires[j].Pressure;
                }

                if ((currentCar.Year >= 2017) && (currentCar.Engine.HorsePower > 330) &&
                    (9 < allTirePressures && allTirePressures < 10))
                {
                    currentCar.Drive(20);
                    currentCar.PrintCarData();
                }
            }
        }
    }
}
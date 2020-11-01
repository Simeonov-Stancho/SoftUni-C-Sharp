using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SpecialCars
{
    public class Car
    {
        public Car(string make, string model, int year, double fuelQuantity,
            double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(int distance)
        {
            this.FuelQuantity = this.FuelQuantity - distance * this.FuelConsumption / 100.0;
        }

        public void PrintCarData()
        {
            Console.WriteLine($"Make: {this.Make}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Year: {this.Year}");
            Console.WriteLine($"HorsePowers: {this.Engine.HorsePower}");
            Console.WriteLine($"FuelQuantity: {this.FuelQuantity}");
        }
    }
}
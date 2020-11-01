using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Vehicle> vehicles = new List<Vehicle>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = command[0];
                string model = command[1];
                string color = command[2];
                double horsePower = double.Parse(command[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);

                vehicles.Add(vehicle);
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(vehicles.FirstOrDefault(x => x.Model == input).ToString());
            }

            List<Vehicle> cars = vehicles.FindAll(x => x.Type == "car");
            double carHorsePower = cars.Sum(x => x.HorsePower);
            double carAveragePower = carHorsePower / cars.Count;

            List<Vehicle> trucks = vehicles.FindAll(x => x.Type == "truck");
            double truckHorsePower = trucks.Sum(x => x.HorsePower);
            double truckAveragePower = truckHorsePower / trucks.Count;

            if (cars.Count == 0)
            {
                carAveragePower = 0;
            }

            if (trucks.Count == 0)
            {
                truckAveragePower = 0;
            }

            Console.WriteLine($"Cars have average horsepower of: {carAveragePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAveragePower:f2}.");

        }

        public class Vehicle
        {
            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double HorsePower { get; set; }

            public Vehicle(string type, string model, string color, double horesePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horesePower;
            }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (Type == "car")
                {
                    stringBuilder.AppendLine($"Type: Car");
                }

                else
                {
                    stringBuilder.AppendLine($"Type: Truck");
                }

                stringBuilder.AppendLine($"Model: {Model}");
                stringBuilder.AppendLine($"Color: {Color}");
                stringBuilder.AppendLine($"Horsepower: {HorsePower}");

                return stringBuilder.ToString().TrimEnd();
            }
        }
    }
}

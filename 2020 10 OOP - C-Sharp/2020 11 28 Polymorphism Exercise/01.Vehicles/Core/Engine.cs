using _01.Vehicles.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Vehicles.Core
{
    public class Engine
    {
        public IReader reader;
        public IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArg = this.reader.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                try
                {
                    ExecuteCommand(car, truck, commandArg);
                }

                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }

        private void ExecuteCommand(Vehicle car, Vehicle truck, string[] commandArg)
        {
            string command = commandArg[0];
            string vehicleType = commandArg[1];
            double num = double.Parse(commandArg[2]);

            if (command == "Drive")
            {
                if (vehicleType == "Car")
                {
                    this.writer.WriteLine(car.Drive(num));
                }

                else if (vehicleType == "Truck")
                {
                    this.writer.WriteLine(truck.Drive(num));
                }
            }

            else if (command == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(num);
                }

                else if (vehicleType == "Truck")
                {
                    truck.Refuel(num);
                }
            }
        }

        private Vehicle CreateVehicle()
        {
            string[] vehicleArg = this.reader.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            string vehicleType = vehicleArg[0];
            double fuelQuantity = double.Parse(vehicleArg[1]);
            double fuelConsumption = double.Parse(vehicleArg[2]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }

            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}

using System;
using System.Linq;

using _01.VehiclesKristiyanIvanov.Core.Contracts;
using _01.VehiclesKristiyanIvanov.Factories;
using _01.VehiclesKristiyanIvanov.IO.Contracts;
using _01.VehiclesKristiyanIvanov.Models;

namespace _01.VehiclesKristiyanIvanov.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        private readonly VehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = this.ReadVehicleArg();
            Vehicle truck = this.ReadVehicleArg();
            Vehicle bus = this.ReadVehicleArg();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArg = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArg[0];
                string vehicleType = commandArg[1];
                double arg = double.Parse(commandArg[2]); // can be distance or liters

                try
                {
                    if (commandType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.writer.WriteLine(car.Drive(arg));
                        }

                        else if (vehicleType == "Truck")
                        {
                            this.writer.WriteLine(truck.Drive(arg));
                        }

                        else if (vehicleType == "Bus")
                        {
                            this.writer.WriteLine(bus.Drive(arg));
                        }
                    }

                    else if (commandType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(arg);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(arg);
                        }

                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(arg);
                        }
                    }

                    else if (commandType == "DriveEmpty")
                    {
                        if (vehicleType == "Bus")
                        {
                            this.writer.WriteLine(bus.DriveEmpty(arg));
                        }
                    }
                }

                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }

        private Vehicle ReadVehicleArg()
        {
            string[] vehicleArg = this.reader.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            Vehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleArg);
            return vehicle;
        }
    }
}

using System;

using _01.VehiclesKristiyanIvanov.Common.Exceptions;
using _01.VehiclesKristiyanIvanov.Models;

namespace _01.VehiclesKristiyanIvanov.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string[] vehicleArg)
        {
            string vehicleType = vehicleArg[0];
            double fuelQuantity = double.Parse(vehicleArg[1]);
            double fuelConsumption = double.Parse(vehicleArg[2]);
            double tankCapacity = double.Parse(vehicleArg[3]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else
            {
                throw new InvalidOperationException(Exceptions.INVALID_VEHICLE_TYPE);
            }

            return vehicle;
        }
    }
}